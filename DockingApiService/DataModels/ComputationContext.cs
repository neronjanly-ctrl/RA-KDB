using CommonTools;
using DockingDataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DockingApiService.DataModels;

public class ComputationContext : DbContext
{
    private readonly IConfiguration _config;
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<ComputationContext> _log;

    public ComputationContext(DbContextOptions<ComputationContext> options, IConfiguration config, IWebHostEnvironment env, ILogger<ComputationContext> logger)
        : base(options)
    {
        _config = config;
        _env = env;
        _log = logger;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_env.IsDevelopment())
            optionsBuilder.EnableSensitiveDataLogging();

        base.OnConfiguring(optionsBuilder);
    }

    #region Build seeding entities

    private static Dictionary<string, string> LoadProperties(string filepath)
    {
        Dictionary<string, string> properties = File.ReadAllLines(filepath)
            .Select(o =>
            {
                int pos = o.IndexOf('=');
                return new[] { o[..pos].Trim(), o[(pos + 1)..].Trim() };
            })
            .ToDictionary(o => o[0], o => o[1]);
        return properties;
    }

    private static Structure BuildStructure(ModelBuilder modelBuilder, string modelDir, long cavityId, int index)
    {
        string propfile = Path.Combine(modelDir, "Properties.txt");

        Dictionary<string, string> properties = LoadProperties(propfile);
        if (!properties.ContainsKey("PdbId"))
            throw new Exception($"{modelDir} doesn't have the PdbId entry");

        string pdbId = properties["PdbId"];

        FileInfo fi = new(propfile);
        string pdbqtFile1 = Path.Combine(modelDir, "AminoAcids.pdbqt");
        string pdbqtFile2 = Path.Combine(modelDir, "AminoAcids_fixed.pdbqt");

        Structure structure = new()
        {
            CavityId = cavityId,
            Index = index,
            ObtainingMethod = string.IsNullOrEmpty(pdbId) ? StructureObtainingMethod.Unknown : StructureObtainingMethod.ImagingTechnique,
            Created = fi.CreationTimeUtc,
            Updated = fi.LastWriteTimeUtc,
            HasBindingLigand = File.Exists(Path.Combine(modelDir, "Ligand.pdb")),
            PdbqtHash = File.Exists(pdbqtFile1) ? File.ReadAllText(pdbqtFile1).ComputeHashInt64() : null,
            PdbqtFixedHash = File.Exists(pdbqtFile2) ? File.ReadAllText(pdbqtFile2).ComputeHashInt64() : null,
        };

        modelBuilder.Entity<Structure>()
            .HasData(structure);

        if (!string.IsNullOrEmpty(pdbId))
        {
            modelBuilder.Entity<Structure>()
                .OwnsOne(o => o.Pdb)
                .HasData(new { StructureCavityId = cavityId, StructureIndex = index, Id = pdbId });
        }

        return structure;
    }

    private static Cavity BuildProteinCavity(ModelBuilder modelBuilder, string cavityDir, string proteinId)
    {
        string bindingCavity = Path.GetFileName(cavityDir);
        DirectoryInfo di = new(cavityDir);

        int structureCount = 0;
        while (Directory.Exists(Path.Combine(cavityDir, $"model_{structureCount + 1}")))
            structureCount++;

        Cavity cavity = new()
        {
            Id = $"{proteinId}_{bindingCavity}".ComputeHashInt64(),
            ProteinId = proteinId,
            BindingSite = bindingCavity,
            Created = di.CreationTimeUtc,
            Updated = di.LastWriteTimeUtc,
            StructureCount = structureCount,
            StructureHasBindingLigands = new bool[structureCount],
            StructureObtainingMethods = new StructureObtainingMethod[structureCount],
        };

        for (int i = 0; i < structureCount; i++)
        {
            string modelDir = Path.Combine(cavityDir, $"model_{i + 1}");
            Structure structure = BuildStructure(modelBuilder, modelDir, cavity.Id, i);
            cavity.StructureHasBindingLigands[i] = structure.HasBindingLigand;
            cavity.StructureObtainingMethods[i] = structure.ObtainingMethod;
        }

        modelBuilder.Entity<Cavity>()
            .HasData(cavity);

        return cavity;
    }

    private static Protein LoadProtein(ModelBuilder modelBuilder, string proteinDir)
    {
        string proteinId = Path.GetFileName(proteinDir);

        string propfilePath = Path.Combine(proteinDir, "Properties.txt");
        FileInfo fi = new(propfilePath);
        Dictionary<string, string> properties = LoadProperties(propfilePath);

        string provisionedCsv = Path.Combine(proteinDir, $"{proteinId}_ProvisionedCompounds.csv");
        bool hasActiveCompounds = File.Exists(provisionedCsv) && File.ReadAllLines(provisionedCsv)
            .ParseCsvRows("IsActive")
            .SelectMany(o => o)
            .Any(o => int.Parse(o) > 0);

        string bioactivitiesTxt = Path.Combine(proteinDir, $"{proteinId}_Bioactivities.txt");
        int rawBioactivitiesCount = !File.Exists(bioactivitiesTxt) ? 0 : File.ReadAllLines(bioactivitiesTxt).Length - 1;

        string bioactivitiesCsv = Path.Combine(proteinDir, $"{proteinId}_Bioactivities.csv");
        int bioactivitiesCount = !File.Exists(bioactivitiesCsv) ? 0 : File.ReadAllLines(bioactivitiesCsv)
            .ParseCsvRows("Molecule ChEMBL ID")
            .SelectMany(o => o)
            .Count(o => o.StartsWith("CHEMBL"));

        Protein protein = new()
        {
            Id = proteinId,
            GeneSymbol = properties["GeneSymbol"],
            OrganismSymbol = properties["OrganismSymbol"],
            ProteinSymbol = properties["ProteinSymbol"],
            ProteinName = properties["ProteinName"],
            Organism = properties["Organism"],
            DomainCount = 0,
            Created = fi.CreationTimeUtc,
            Updated = fi.LastWriteTimeUtc,
            HasActiveChemblCompounds = hasActiveCompounds,
            HasChemblCompounds = File.Exists(Path.Combine(proteinDir, $"{proteinId}_ChemblCompounds.fp2")),
            HasTrainedModels = File.Exists(Path.Combine(proteinDir, "Model_RF.m")),
            StructureCount = 0,
            RawBioactivityCount = rawBioactivitiesCount,
            BioactivityCount = bioactivitiesCount,
        };

        foreach (string cavityDir in Directory.GetDirectories(proteinDir))
        {
            Cavity cavity = BuildProteinCavity(modelBuilder, cavityDir, proteinId);
            protein.StructureCount += cavity.StructureCount;
        }

        modelBuilder.Entity<Protein>()
            .HasData(protein);

        ProteinProperties proteinProps = new()
        {
            ProteinId = proteinId,
            Synonyms = properties["Synonyms"].Split(',').Select(o => o.Trim()).Where(o => !string.IsNullOrEmpty(o) && o != "-").ToArray(),
            LocusType = properties["LocusType"],
            ChromosomalLocation = properties["ChromosomalLocation"],
            GeneFamily = properties["GeneFamily"],
        };

        modelBuilder.Entity<ProteinProperties>()
            .HasData(proteinProps);

        if (!string.IsNullOrEmpty(properties["UniProtId"]))
        {
            modelBuilder.Entity<ProteinProperties>()
                .OwnsOne(o => o.UniProt)
                .HasData(new { ProteinPropertiesProteinId = proteinId, Id = properties["UniProtId"] });
        }

        if (!string.IsNullOrEmpty(properties["EnsemblId"]))
        {
            modelBuilder.Entity<ProteinProperties>()
                .OwnsOne(o => o.Ensembl)
                .HasData(new { ProteinPropertiesProteinId = proteinId, Id = properties["EnsemblId"] });
        }

        if (!string.IsNullOrEmpty(properties["GenBankId"]))
        {
            modelBuilder.Entity<ProteinProperties>()
                .OwnsOne(o => o.GenBank)
                .HasData(new { ProteinPropertiesProteinId = proteinId, Id = properties["GenBankId"] });
        }

        if (!string.IsNullOrEmpty(properties["NcbiId"]))
        {
            modelBuilder.Entity<ProteinProperties>()
                .OwnsOne(o => o.Ncbi)
                .HasData(new { ProteinPropertiesProteinId = proteinId, Id = properties["NcbiId"] });
        }

        if (!string.IsNullOrEmpty(properties["HgncId"]))
        {
            modelBuilder.Entity<ProteinProperties>()
                .OwnsOne(o => o.Hgnc)
                .HasData(new { ProteinPropertiesProteinId = proteinId, Id = int.Parse(properties["HgncId"]) });
        }

        if (!string.IsNullOrEmpty(properties["ChemblId"]))
        {
            modelBuilder.Entity<ProteinProperties>()
                .OwnsOne(o => o.Chembl)
                .HasData(new { ProteinPropertiesProteinId = proteinId, Id = properties["ChemblId"] });
        }

        return protein;
    }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ? : 0 or 1
        // * : 0 or many
        // + : 1 or many
        //
        //  User      Domain    ProteinProperties
        //    \?     */     \*     1/
        //     \     /       \     /
        //     *\   /*       *\   /1
        //       Job         Protein
        //     */  |         1/   \1
        //     /   |         /     \
        //   */    |        /*      \
        // Ligand  |     Cavity      \*
        //    \1   |    1/        Structure
        //     \   |    /
        //     *\  |*  /*
        //       Result

        if (Database.IsSqlite())
        {
            // SQLite does not have proper support for DateTime via Entity Framework Core, see the limitations
            // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
            // To work around this, when the Sqlite database provider is used, all model properties of type DateTime
            // use the DateTimeToTicksConverter
            // Based on: https://github.com/aspnet/EntityFrameworkCore/issues/10784#issuecomment-415769754
            modelBuilder.UseValueConverterForType<DateTime>(new DateTimeToTicksConverter());
            // Conversion can't be applied to properties on owned entity
            //modelBuilder.UseValueConverterForType<TimeSpan>(new TimeSpanToTicksConverter());
        }

        // Build keys and indices
        modelBuilder.Entity<Result>()
            .HasKey(o => new { o.JobId, o.LigandId, o.CavityId });

        modelBuilder.Entity<JobDomain>()
            .HasKey(o => new { o.JobId, o.DomainId });

        modelBuilder.Entity<DomainProtein>()
            .HasKey(o => new { o.DomainId, o.ProteinId });

        modelBuilder.Entity<JobLigand>()
            .HasKey(o => new { o.JobId, o.LigandId });

        modelBuilder.Entity<Structure>()
            .HasKey(o => new { o.CavityId, o.Index });

        modelBuilder.Entity<Result>()
            .HasIndex(o => new { o.LigandId, o.CavityId });

        modelBuilder.Entity<Result>()
            .HasIndex(o => o.CavityId);

        modelBuilder.Entity<Protein>()
            .HasIndex(o => new { o.ProteinSymbol, o.OrganismSymbol })
            .IsUnique();

        // Store procedures
        modelBuilder.UseJsonArrayConverterForArrayType<int>();
        modelBuilder.UseJsonArrayConverterForArrayType<bool>();
        modelBuilder.UseJsonArrayConverterForArrayType<float>();
        modelBuilder.UseJsonArrayConverterForArrayType<float?>();
        modelBuilder.UseJsonArrayConverterForArrayType<string>();
        modelBuilder.UseJsonArrayConverterForArrayType<StructureObtainingMethod>();

        // Data seeding
        string workdir = Path.Combine(_env.ContentRootPath, "Workspace", "Receptors");
        Dictionary<string, Protein> proteins = new();

        foreach (string proteinDir in Directory.GetDirectories(workdir))
        {
            Protein protein = LoadProtein(modelBuilder, proteinDir);
            proteins[protein.Id] = protein;
        }

        // Note: data seeding doesn't support assignment through navigation property
        IEnumerable<IConfigurationSection> domainCfgs = _config.GetSection("DataSeeding").GetSection("Domains").GetChildren();

        foreach (IConfigurationSection domainCfg in domainCfgs)
        {
            _log.LogInformation("Loading domain {DomainId}", domainCfg["Id"]);

            // Load target names from configuration
            string[] targets = domainCfg.GetArray<string>("Targets");

            Domain domain = new()
            {
                Id = domainCfg["Id"],
                IsPublic = domainCfg.GetValue<bool>("IsPublic"),
                Name = domainCfg["Name"],
                Description = domainCfg["Description"],
                Citation = domainCfg["Citation"],
                Keywords = domainCfg.GetArray<string>("Keywords"),
                Created = DateTime.Parse(domainCfg["Created"]),
                ProteinCount = targets.Length,
            };

            modelBuilder.Entity<Domain>()
                .HasData(domain);

            // Load all proteins for the specific domain
            foreach (string target in targets)
            {
                if (!proteins.ContainsKey(target))
                    throw new Exception($"Target {target} for domain {domain.Id} could not be found.");

                proteins[target].DomainCount++;

                modelBuilder.Entity<DomainProtein>()
                    .HasData(new DomainProtein { DomainId = domain.Id, ProteinId = proteins[target].Id });
            }
        }

        IEnumerable<IConfigurationSection> tagCfgs = _config.GetSection("DataSeeding").GetSection("Tags").GetChildren();
        foreach (IConfigurationSection tagCfg in tagCfgs)
        {
            string id = tagCfg["Id"], name = tagCfg["Name"];

            ProteinTag tag = new()
            {
                Id = id,
                Name = name,
            };

            modelBuilder.Entity<ProteinTag>()
                .HasData(tag);

            string[] proteinIds = tagCfg.GetArray<string>("Proteins");

            modelBuilder.Entity("ProteinProteinTag").HasData(proteinIds.Select(o => new
            {
                ProteinsId = o,
                TagsId = id,
            }));
        }
    }

    public DbSet<Domain> Domains { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Ligand> Ligands { get; set; }
    public DbSet<Protein> Proteins { get; set; }
    public DbSet<ProteinTag> ProteinTags { get; set; }
    public DbSet<Structure> Structures { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cavity> Cavities { get; set; }
    public DbSet<ProteinProperties> ProteinProperties { get; set; }

    public DbSet<Docking> Dockings { get; set; }
    public DbSet<RunningJob> RunningJobs { get; set; }
}
