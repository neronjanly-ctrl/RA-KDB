using ChemicalFunctions;
using CommonTools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FetchProteinData
{
    internal class Program
    {
        private static ILogger Log => Logger.Current;

        private static IEnumerable<string> GenCsv(IDictionary<string, IList<string>> proteins, string[] headers)
        {
            yield return headers.FormatCsvRow();

            foreach (KeyValuePair<string, IList<string>> protein in proteins)
            {
                yield return protein.Value.FormatCsvRow();
            }
        }

        private static void PreparePropertiesForProteins(string workdir)
        {
            string[] headers = {
                "GeneSymbol",
                "ProteinSymbol",
                "OrganismSymbol",

                "ProteinName",
                "Organism",
                "Synonyms",
                "LocusType",
                "ChromosomalLocation",
                "GeneFamily",

                "HgncId",
                "UniProtId",
                "EnsemblId",
                "GenBankId",
                "NcbiId",
                "ChemblId",
            };

            using (Log.BeginScope(workdir))
            {
                string outputFile = Path.Combine(workdir, "Proteins.csv");

                ConcurrentDictionary<string, IList<string>> dict = new();

                Parallel.ForEach(Directory.GetDirectories(workdir), proteinDir =>
                {
                    string protein = Path.GetFileName(proteinDir);

                    using (Log.BeginScope(protein))
                    {
                        string propname = Path.Combine(workdir, protein, "Properties.txt");
                        if (File.Exists(propname))
                            return;

                        IDictionary<string, object> bag = new Dictionary<string, object>()
                            .SetUniProtId(protein)
                            .FetchUniProtJson(true);

                        if (bag.GetUniProtJson() == null)
                        {
                            Logger.Current.LogWarning("Falling back to unreviewed uniprot results for {protein}", protein);
                            bag.FetchUniProtJson(false);
                        }

                        string proteinSymbol = null, organismSymbol = null;

                        if (bag.GetUniProtJson() == null)
                        {
                            string prop = Path.Combine(Directory.GetDirectories(proteinDir)[0], "model_1", "Properties.txt");
                            string uniprot = File.ReadAllLines(prop).Where(o => o.StartsWith("UniProtId=")).Single()["UniProtId=".Length..];
                            bag.SetUniProtId(uniprot).FetchUniProtHtml();
                            proteinSymbol = protein.Split('_')[0];
                            organismSymbol = protein.Split('_')[1];
                        }

                        bag.ParseUniProtJson();

                        if (bag.GetProteinSymbol() == null)
                        {
                            Logger.Current.LogError("Failed to process with {protein}", protein);
                            return;
                        }

                        int? hgncId = bag.GetHgncId();
                        string geneName = bag.GetGeneName()?.ToUpper();

                        if (hgncId != null)
                        {
                            bag.FetchGeneNamesJson()
                                .ParseGeneNamesData();
                        }

                        proteinSymbol ??= bag.GetUniProtId() != bag.GetProteinSymbol() ? bag.GetProteinSymbol() : geneName;
                        organismSymbol ??= bag.GetOrganismSymbol();
                        geneName ??= proteinSymbol;

                        string newProteinDir = Path.Combine(workdir, $"{proteinSymbol}_{organismSymbol}");
                        if (newProteinDir != proteinDir)
                        {
                            Directory.Move(proteinDir, newProteinDir);
                        }

                        string text = string.Join("\n", new Dictionary<string, string>()
                        {
                            { "GeneSymbol", bag.GetApprovedSymbol()?.ToUpper() ?? geneName },
                            { "ProteinSymbol", proteinSymbol },
                            { "OrganismSymbol", organismSymbol },

                            { "ProteinName", bag.GetApprovedName() },
                            { "Organism", string.Join(';', bag.GetOrganisms()) },
                            { "Synonyms", bag.GetAliasNames() },
                            { "LocusType", bag.GetLocusType() },
                            { "ChromosomalLocation", bag.GetChromosomeLocation() },
                            { "GeneFamily", bag.GetGeneGroups() },

                            { "HgncId", bag.GetHgncId()?.ToString() },
                            { "UniProtId", bag.GetUniProtId() },
                            { "EnsemblId", bag.GetEnsemblId() },
                            { "GenBankId", bag.GetINSDCId() },
                            { "NcbiId", bag.GetRefSeqId() },
                            { "ChemblId", bag.GetChemblId() },
                        }.Select(o => $"{o.Key}={o.Value}")) + "\n";

                        if (protein == bag.GetUniProtId())
                            propname = Path.Combine(newProteinDir, "Properties.txt");

                        if (!File.Exists(propname))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(propname));
                            Logger.Current.LogInformation($"Writing properties to {propname}");

                            File.WriteAllText(propname, text);
                        }
                        else
                        {
                            Logger.Current.LogInformation($"Skipping existing {propname}");
                        }

                        dict[geneName] = new[]{
                            bag.GetApprovedSymbol()?.ToUpper() ?? geneName,
                            proteinSymbol,
                            organismSymbol,
                            bag.GetApprovedName(),
                            string.Join(';', bag.GetOrganisms()),
                            bag.GetAliasNames(),
                            bag.GetLocusType(),
                            bag.GetChromosomeLocation(),
                            bag.GetGeneGroups(),
                            bag.GetHgncId()?.ToString(),
                            bag.GetUniProtId(),
                            bag.GetEnsemblId(),
                            bag.GetINSDCId(),
                            bag.GetRefSeqId(),
                            bag.GetChemblId(),
                        };
                    }
                });

                IEnumerable<string> csv = GenCsv(dict, headers);

                File.WriteAllLines(outputFile, csv, Encoding.UTF8);
            }
        }

        private static void PreparePropertiesForPdbModels(string workdir)
        {
            foreach (string dir in Directory.GetDirectories(workdir))
            {
                string root = Path.GetFileName(dir);
                string[] fields = root.Split('_');

                string[] subdirs = Directory.GetDirectories(dir);
                string[] subdirnames = subdirs.Select(Path.GetFileName).ToArray();

                int cavitydircount = subdirnames.Count(o => o.StartsWith("orthosteric") || o.StartsWith("allosteric"));
                int pdbdircount = subdirnames.Count(o => o.Length == 4 && Regex.IsMatch(o, "^[a-zA-Z0-9]{4}$"));

                if (subdirs.Length == 0)
                {
                    Logger.Current.LogWarning("No structures detected in {protein_dir}", dir);
                    continue;
                }

                if (cavitydircount > 0 && pdbdircount > 0)
                {
                    Logger.Current.LogError("Mixture of cavity and pdb directories in {protein_dir}", dir);
                    continue;
                }

                if (cavitydircount + pdbdircount < subdirs.Length)
                {
                    Logger.Current.LogError("Unknown directories found in {protein_dir}", dir);
                    continue;
                }

                // Only pdb directories
                if (pdbdircount == subdirs.Length)
                {
                    Logger.Current.LogWarning("No cavity directory found, creating default orthosteric in {protein_dir}", dir);
                    string cavitydir = Path.Combine(dir, "orthosteric");

                    Directory.CreateDirectory(cavitydir);
                    foreach (string subdir in subdirs)
                    {
                        Directory.Move(subdir, Path.Combine(cavitydir, Path.GetFileName(subdir)));
                    }

                    subdirs = new[] { cavitydir };
                    cavitydircount = 1;
                }

                // Now it can only contain cavity directories
                Debug.Assert(cavitydircount == subdirs.Length);

                foreach (string subdir in subdirs)
                {
                    string cavity = Path.GetFileName(subdir);
                    Logger.Current.LogInformation("{cavity_dir}", subdir);

                    int model = 1;
                    foreach (string pdbdir in Directory.GetDirectories(subdir))
                    {
                        string pdb = Path.GetFileName(pdbdir);

                        if (!Regex.IsMatch(pdb, "^[a-zA-Z0-9]{4}$"))
                        {
                            Logger.Current.LogWarning("Not a PDB named directory: {pdb_dir}", pdbdir);
                            continue;
                        }

                        string modeldir = Path.Combine(subdir, $"model_{model++}");

                        Logger.Current.LogInformation("Renaming {pdb_dir} to {model_dir}", pdbdir, modeldir);
                        IDictionary<string, object> bag = new Dictionary<string, object>()
                            .SetPdbEntry(pdb)
                            .DownloadRcsbProfileHtml()
                            .ParseRcsbProfileHtml();

                        string[] uniprots = bag.GetUniProtIds();

                        foreach (string uniprot in uniprots)
                        {
                            bag.SetUniProtId(uniprot)
                                .FetchUniProtJson(true)
                                .ParseUniProtJson();

                            if (bag.GetUniProtSymbol() == root)
                            {
                                uniprots = new[] { uniprot };
                                break;
                            }
                        }

                        Logger.Current.LogInformation("PDB {pdb}: {uniprot_list}", pdb, string.Join(",", uniprots));

                        string propfile = Path.Combine(pdbdir, "Properties.txt");
                        File.WriteAllText(propfile, $"PdbId={pdb}\nUniProtId={string.Join(",", uniprots)}\nProteinSymbol={fields[0]}\nOrganismSymbol={fields[1]}\nBindingCavity={cavity}\n");

                        Directory.Move(pdbdir, modeldir);
                    }
                }
            }
        }

        private static void Main()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Debug))
                .BuildServiceProvider();

            Logger.Current = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

            //string workdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Git", "GenericComputationPlatform", "DockingApiService", "Workspace", "Receptors");
            string workdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "receptors");
            PreparePropertiesForProteins(workdir);

            PreparePropertiesForPdbModels(workdir);
        }
    }
}
