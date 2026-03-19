using CommonTools;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DockingApiService.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create temporary tables
            migrationBuilder.CreateTable(
                name: "_Proteins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NewId = table.Column<long>(nullable: false),
                });

            migrationBuilder.CreateTable(
                name: "_Ligands",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Smiles = table.Column<string>(nullable: true),
                    DepictionSvg = table.Column<string>(nullable: true),
                    DepictionSvg3D = table.Column<string>(nullable: true),
                    BbbAdaboostMACCS = table.Column<float>(nullable: true),
                    BbbSVMMACCS = table.Column<float>(nullable: true),
                    BbbAdaboostPubChem = table.Column<float>(nullable: true),
                    BbbSVMPubChem = table.Column<float>(nullable: true),
                    BbbAdaboostMolprint2D = table.Column<float>(nullable: true),
                    BbbSVMMolprint2D = table.Column<float>(nullable: true),
                    BbbAdaboostDayLight = table.Column<float>(nullable: true),
                    BbbSVMDayLight = table.Column<float>(nullable: true),
                    Fingerprint = table.Column<byte[]>(nullable: true),
                    Progress = table.Column<int>(nullable: false),
                });

            migrationBuilder.CreateTable(
                name: "_Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LigandId = table.Column<long>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Started = table.Column<DateTimeOffset>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                });

            migrationBuilder.CreateTable(
                name: "_Results",
                columns: table => new
                {
                    LigandId = table.Column<long>(nullable: false),
                    ProteinId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: false),
                    Score1 = table.Column<float>(nullable: true),
                    Score2 = table.Column<float>(nullable: true),
                    Score3 = table.Column<float>(nullable: true),
                    Score4 = table.Column<float>(nullable: true),
                    Prediction = table.Column<int>(nullable: true),
                    ConfidenceLevel = table.Column<float>(nullable: true),
                    SimilarChemblId = table.Column<int>(nullable: true),
                    SimilarSmiles = table.Column<string>(nullable: true),
                    SimilarFingerprint = table.Column<byte[]>(nullable: true)
                });

            // Move data from old tables to temporary tables
            var oldProteinSymbols = new[]{
                "HTR1A", "HTR1B", "HTR1D", "HTR1E", "HTR1F", "HTR2A", "HTR2B", "HTR2C",
                "HTR4", "HTR5A", "HTR6", "HTR7", "ADORA1", "ADORA2A", "ADORA2B", "ADORA3",
                "ADRA1D", "ADRA2A", "ADRA2B", "ADRA2C", "AGTR2", "ADRB1", "ADRB2", "ADRB3",
                "BDKRB2", "CALCR", "CNR1", "CNR2", "CCKAR", "CCKBR", "CCR1", "CCR2",
                "CCR4", "CCR5", "CXCR1", "CXCR2", "CXCR3", "CXCR4", "CYSLTR1", "DRD1",
                "DRD2", "DRD3", "DRD4", "DRD5", "EDNRA", "GABBR1", "HRH1", "HRH2",
                "HRH3", "HRH4", "CHRM1", "CHRM2", "CHRM3", "CHRM4", "CHRM5", "MC1R",
                "MC2R", "MC3R", "MC4R", "MC5R", "GRM1", "GRM2", "GRM3", "GRM4",
                "GRM5", "GRM6", "GRM7", "GRM8", "TACR1", "TACR2", "OPRL1", "NPBWR1",
                "NPFFR1", "NPSR1", "NPY1R", "NPY2R", "NPY4R", "NPY5R", "OPRD1", "OPRK1",
                "OPRM1", "PTAFR", "TSHR", "TAAR1", "VIPR1", "AVPR1A"
            };

            migrationBuilder.Sql(string.Join(";", oldProteinSymbols.Select((o, i) => $"insert into _Proteins(Id, NewId) values({i}, {o.ComputeHashInt64()})")));

            migrationBuilder.Sql("insert into _Tasks(Id, Name, LigandId, Created, Started, Updated, Status) "
                + "select Id, Name, LigandId, Created, Started, Updated, Status from DockingTasks");

            migrationBuilder.Sql("insert into _Results(LigandId, ProteinId, Created, Updated, Score1, Score2, Score3, Score4, Prediction, ConfidenceLevel, SimilarChemblId, SimilarSmiles, SimilarFingerprint) "
                + "select LigandId, ProteinId, Created, Updated, Score1, Score2, Score3, Score4, Prediction, ConfidenceLevel, SimilarChemblId, SimilarSmiles, SimilarFingerprint from DockingResults");

            migrationBuilder.Sql("insert into _Ligands(Id, Smiles, DepictionSvg, DepictionSvg3D, BbbAdaboostMACCS, BbbSVMMACCS, BbbAdaboostPubChem, BbbSVMPubChem, BbbAdaboostMolprint2D, BbbSVMMolprint2D, BbbAdaboostDayLight, BbbSVMDayLight, Fingerprint, Progress) "
                + "select Id, Smiles, DepictionSvg, DepictionSvg3D, BbbAdaboostMACCS, BbbSVMMACCS, BbbAdaboostPubChem, BbbSVMPubChem, BbbAdaboostMolprint2D, BbbSVMMolprint2D, BbbAdaboostDayLight, BbbSVMDayLight, Fingerprint, Progress from DockingLigands");

            // Remove old tables
            migrationBuilder.DropTable("DockingTasks");
            migrationBuilder.DropTable("DockingResults");
            migrationBuilder.DropTable("DockingLigands");

            // Create all new tables from draft
            CreateNewSchemeAndSeedData(migrationBuilder);

            // Move data from temporary tables to new tables
            // Current fingerprints all are in FP2 type
            migrationBuilder.Sql("insert into DockingLigands(Id, Smiles, DepictionSvg, DepictionSvg3D, BbbAdaBoostMACCS, BbbSvmMACCS, BbbAdaBoostPubChem, BbbSvmPubChem, BbbAdaBoostMolprint2D, BbbSvmMolprint2D, BbbAdaboostFP2, BbbSvmFP2, FingerprintFP2) "
                + "select Id, Smiles, DepictionSvg, DepictionSvg3D, BbbAdaboostMACCS, BbbSVMMACCS, BbbAdaboostPubChem, BbbSVMPubChem, BbbAdaboostMolprint2D, BbbSVMMolprint2D, BbbAdaboostDayLight, BbbSVMDayLight, Fingerprint from _Ligands");

            // Current tasks are all for GPCR domain(id=1)
            migrationBuilder.Sql("insert into DockingTasks(Id, Name, Created, Started, Updated, Status, "
                + "DomainCount, ProteinCount, LigandCount, ResultCount, "
                + "TimeUsedForStages, TimeUsed, TargetStages, TotalTargetStages, CompletedStages, TotalCompletedStages, PrecompletedStages, TotalPrecompletedStages) "
                + "select Id, Name, Created, Started, Updated, Status, "
                + "1, 86, 1, 86, "
                + "null, cast(a as int) || '.' || substr('0'||cast(a*24%24 as int),-2) || ':' || substr('0' || cast(a*1440%60 as int),-2) || ':' || substr('0' || cast(a*86400%60 as int),-2) || substr(a*86400-cast(a*86400 as int),2,8), '[86,85,86,85,86]', 428, '[86,85,86,85,86]', 428, '[0,0,0,0,0]', 0 from (select *, julianday(updated)-julianday(created) as a from _Tasks)");

            migrationBuilder.Sql("insert into DockingTaskDomain(TaskId, DomainId) select Id, 1 from _Tasks");
            migrationBuilder.Sql("insert into DockingTaskLigand(TaskId, LigandId) select Id, LigandId from _Tasks");

            // Current results are with 0-index proteinId while we need Ids hashed from symbols
            migrationBuilder.Sql("insert into DockingResults(LigandId, ProteinId, Created, Updated, Score1, Score2, Score3, Score4, Prediction, ConfidenceLevel, SimilarChemblId, SimilarSmiles, SimilarFingerprint) "
                + "select LigandId, (select NewId from _Proteins where Id=ProteinId), Created, Updated, Score1, Score2, Score3, Score4, Prediction, ConfidenceLevel, SimilarChemblId, SimilarSmiles, SimilarFingerprint from _Results");

            // Remove temporary tables
            migrationBuilder.DropTable("_Proteins");
            migrationBuilder.DropTable("_Tasks");
            migrationBuilder.DropTable("_Results");
            migrationBuilder.DropTable("_Ligands");
        }

        protected static void CreateNewSchemeAndSeedData(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DockingDomains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ProteinCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockingDomains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DockingLigands",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Smiles = table.Column<string>(nullable: true),
                    DepictionSvg = table.Column<string>(nullable: true),
                    DepictionSvg3D = table.Column<string>(nullable: true),
                    BbbAdaBoostMACCS = table.Column<float>(nullable: true),
                    BbbAdaBoostPubChem = table.Column<float>(nullable: true),
                    BbbAdaBoostMolprint2D = table.Column<float>(nullable: true),
                    BbbAdaboostFP2 = table.Column<float>(nullable: true),
                    BbbSvmMACCS = table.Column<float>(nullable: true),
                    BbbSvmPubChem = table.Column<float>(nullable: true),
                    BbbSvmMolprint2D = table.Column<float>(nullable: true),
                    BbbSvmFP2 = table.Column<float>(nullable: true),
                    FingerprintMACCS = table.Column<byte[]>(nullable: true),
                    FingerprintFP2 = table.Column<byte[]>(nullable: true),
                    FingerprintFP3 = table.Column<byte[]>(nullable: true),
                    FingerprintFP4 = table.Column<byte[]>(nullable: true),
                    FingerprintECFP0 = table.Column<byte[]>(nullable: true),
                    FingerprintECFP2 = table.Column<byte[]>(nullable: true),
                    FingerprintECFP4 = table.Column<byte[]>(nullable: true),
                    FingerprintECFP6 = table.Column<byte[]>(nullable: true),
                    FingerprintECFP8 = table.Column<byte[]>(nullable: true),
                    FingerprintECFP10 = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockingLigands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DockingProteins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApprovedName = table.Column<string>(nullable: true),
                    ApprovedSymbol = table.Column<string>(nullable: true),
                    Synonyms = table.Column<string>(nullable: true),
                    LocusType = table.Column<string>(nullable: true),
                    ChromosomalLocation = table.Column<string>(nullable: true),
                    GeneFamily = table.Column<string>(nullable: true),
                    HasPockets = table.Column<string>(nullable: true),
                    HasKnownLigands = table.Column<bool>(nullable: false),
                    HgncId = table.Column<int>(nullable: false),
                    UniProtId = table.Column<string>(nullable: true),
                    EnsemblId = table.Column<string>(nullable: true),
                    GenBankId = table.Column<string>(nullable: true),
                    NcbiId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockingProteins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DockingTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Started = table.Column<DateTimeOffset>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DomainCount = table.Column<int>(nullable: false),
                    ProteinCount = table.Column<int>(nullable: false),
                    LigandCount = table.Column<int>(nullable: false),
                    ResultCount = table.Column<int>(nullable: false),
                    TimeUsedForStages = table.Column<string>(nullable: true),
                    TimeUsed = table.Column<TimeSpan>(nullable: false),
                    TargetStages = table.Column<string>(nullable: true),
                    TotalTargetStages = table.Column<int>(nullable: false),
                    CompletedStages = table.Column<string>(nullable: true),
                    TotalCompletedStages = table.Column<int>(nullable: false),
                    PrecompletedStages = table.Column<string>(nullable: true),
                    TotalPrecompletedStages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockingTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DockingDomainProtein",
                columns: table => new
                {
                    DomainId = table.Column<int>(nullable: false),
                    ProteinId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockingDomainProtein", x => new { x.DomainId, x.ProteinId });
                    table.ForeignKey(
                        name: "FK_DockingDomainProtein_DockingDomains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "DockingDomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DockingDomainProtein_DockingProteins_ProteinId",
                        column: x => x.ProteinId,
                        principalTable: "DockingProteins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DockingResults",
                columns: table => new
                {
                    LigandId = table.Column<long>(nullable: false),
                    ProteinId = table.Column<long>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: false),
                    Score1 = table.Column<float>(nullable: true),
                    Score2 = table.Column<float>(nullable: true),
                    Score3 = table.Column<float>(nullable: true),
                    Score4 = table.Column<float>(nullable: true),
                    Prediction = table.Column<int>(nullable: true),
                    ConfidenceLevel = table.Column<float>(nullable: true),
                    SimilarChemblId = table.Column<int>(nullable: true),
                    SimilarSmiles = table.Column<string>(nullable: true),
                    SimilarFingerprint = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockingResults", x => new { x.LigandId, x.ProteinId });
                    table.ForeignKey(
                        name: "FK_DockingResults_DockingLigands_LigandId",
                        column: x => x.LigandId,
                        principalTable: "DockingLigands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DockingResults_DockingProteins_ProteinId",
                        column: x => x.ProteinId,
                        principalTable: "DockingProteins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DockingTaskDomain",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    DomainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockingTaskDomain", x => new { x.TaskId, x.DomainId });
                    table.ForeignKey(
                        name: "FK_DockingTaskDomain_DockingDomains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "DockingDomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DockingTaskDomain_DockingTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "DockingTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DockingTaskLigand",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    LigandId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockingTaskLigand", x => new { x.TaskId, x.LigandId });
                    table.ForeignKey(
                        name: "FK_DockingTaskLigand_DockingLigands_LigandId",
                        column: x => x.LigandId,
                        principalTable: "DockingLigands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DockingTaskLigand_DockingTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "DockingTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DockingDomains",
                columns: new[] { "Id", "FullName", "Name", "ProteinCount" },
                values: new object[] { 1, "Drug abuse related G protein-coupled receptor", "DAKB-GPCRs", 86 });

            migrationBuilder.InsertData(
                table: "DockingDomains",
                columns: new[] { "Id", "FullName", "Name", "ProteinCount" },
                values: new object[] { 2, "Cardiovascular Disease Related Protein Targets", "CVD Targets", 399 });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5082567609285176849L, "phosphodiesterase 6C", "PDE6C", "10q23.33", "ENSG00000095464", "U31973", "Phosphodiesterases", true, "[true,false,false]", 8787, "gene with protein product", "NM_006204", "[\"Cone cGMP-specific 3'\",\"5'-cyclic phosphodiesterase subunit alpha\"]", "P51160" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8512063516045336032L, "lysine demethylase 6A", "KDM6A", "Xp11.3", "ENSG00000147050", "AF000992", "Lysine demethylases,Tetratricopeptide repeat domain containing", true, "[true,false,false]", 12637, "gene with protein product", "NM_021140", "[]", "O15550" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3893449195903294096L, "mitogen-activated protein kinase 13", "MAPK13", "6p21.31", "ENSG00000156711", "Y10488", "Mitogen-activated protein kinases", true, "[true,false,false]", 6875, "gene with protein product", "NM_002754", "[]", "O15264" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8990962930432014842L, "serine hydroxymethyltransferase 1", "SHMT1", "17p11.2", "ENSG00000176974", "", "", true, "[true,false,false]", 10850, "gene with protein product", "NM_004169", "[\"cytoplasmic serine hydroxymethyltransferase\",\"14 kDa protein\"]", "P34896" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5780002788493544135L, "coagulation factor VII", "F7", "13q34", "ENSG00000057593", "", "Gla domain containing", true, "[true,false,false]", 3544, "gene with protein product", "NM_000131", "[\"eptacog alfa\",\"FVII coagulation protein\",\"factor VII\"]", "P08709" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1416867075874855836L, "phosphodiesterase 1B", "PDE1B", "12q13.2", "ENSG00000123360", "U56976", "Phosphodiesterases", true, "[true,false,false]", 8775, "gene with protein product", "NM_000924", "[]", "Q01064" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3731591095676979226L, "calcium/calmodulin dependent protein kinase II gamma", "CAMK2G", "10q22.2", "ENSG00000148660", "U81554", "Calmodulin dependent protein kinases", true, "[true,false,false]", 1463, "gene with protein product", "NM_172169", "[]", "Q13555" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6974341634385238706L, "aquaporin 4", "AQP4", "18q11.2", "ENSG00000171885", "U63622", "Aquaporins", true, "[true,false,false]", 637, "gene with protein product", "NM_001650", "[]", "P55087" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1600792638845990025L, "carboxypeptidase B2", "CPB2", "13q14.13", "ENSG00000080618", "M75106", "M14 carboxypeptidases", true, "[true,false,false]", 2300, "gene with protein product", "NM_001872", "[\"thrombin-activatable fibrinolysis inhibitor\",\"carboxypeptidase U\",\"plasma carboxypeptidase B\",\"carboxypeptidase R\"]", "Q96IY4" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3732836808458950942L, "cytochrome P450 family 21 subfamily A member 2", "CYP21A2", "6p21.33", "ENSG00000231852", "X58906", "Cytochrome P450 family 21", true, "[true,false,false]", 2600, "gene with protein product", "NM_000500", "[\"Steroid 21-monooxygenase\"]", "P08686" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8871344038219058376L, "neurotrophic receptor tyrosine kinase 3", "NTRK3", "15q25.3", "ENSG00000140538", "U05012", "I-set domain containing,Receptor tyrosine kinases", true, "[true,false,false]", 8033, "gene with protein product", "NM_001007156", "[]", "Q16288" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7992529926321588240L, "neurotrophic receptor tyrosine kinase 1", "NTRK1", "1q23.1", "ENSG00000198400", "Y09028", "Immunoglobulin like domain containing,Receptor tyrosine kinases", true, "[true,false,false]", 8031, "gene with protein product", "NM_002529", "[\"high affinity nerve growth factor receptor\"]", "P04629" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1252892664207953598L, "apurinic/apyrimidinic endodeoxyribonuclease 1", "APEX1", "14q11.2", "ENSG00000100823", "X59764", "SET complex,Endoribonucleases", true, "[true,false,false]", 587, "gene with protein product", "NM_001641", "[]", "P27695" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3606856980312601334L, "O-6-methylguanine-DNA methyltransferase", "MGMT", "10q26.3", "ENSG00000170430", "M29971", "", true, "[true,false,false]", 7059, "gene with protein product", "NM_002412", "[\"methylated-DNA--protein-cysteine methyltransferase\"]", "P16455" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -87818609146488774L, "calcium sensing receptor", "CASR", "3q13.33-q21.1", "ENSG00000036828", "U20760", "Calcium sensing receptors", true, "[true,false,false]", 1514, "gene with protein product", "NM_000388", "[\"severe neonatal hyperparathyroidism\"]", "P41180" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1541457873568674976L, "FTO, alpha-ketoglutarate dependent dioxygenase", "FTO", "16q12.2", "ENSG00000140718", "BC003583", "Alkylation repair homologs", true, "[true,false,false]", 24678, "gene with protein product", "NM_001080432", "[\"alkB homolog 9\",\"alpha-ketoglutarate-dependent dioxygenase\"]", "Q9C0B1" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 377500572444435992L, "nuclear receptor subfamily 3 group C member 2", "NR3C2", "4q31", "ENSG00000151623", "M16801", "Nuclear hormone receptors", true, "[true,false,false]", 7979, "gene with protein product", "NM_000901", "[]", "P08235" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -9128521183371756365L, "nuclear receptor subfamily 3 group C member 1", "NR3C1", "5q31.3", "ENSG00000113580", "X03225", "Nuclear hormone receptors", true, "[true,false,false]", 7978, "gene with protein product", "NM_000176", "[\"glucocorticoid receptor\"]", "P04150" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4268531097163778994L, "adenosylhomocysteinase", "AHCY", "20q11.22", "ENSG00000101444", "M61832", "", true, "[true,false,false]", 343, "gene with protein product", "NM_000687", "[]", "P23526" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2937038222490791199L, "corticotropin releasing hormone receptor 1", "CRHR1", "17q21.31", "ENSG00000120088", "L23332", "Corticotropin releasing hormone receptors", true, "[true,false,false]", 2357, "gene with protein product", "NM_001145146", "[\"corticotropin-releasing factor receptor\"]", "P34998" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1390479403806925448L, "xanthine dehydrogenase", "XDH", "2p23.1", "ENSG00000158125", "D11456", "", true, "[true,false,false]", 12805, "gene with protein product", "NM_000379", "[]", "P47989" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7877626049082496699L, "cyclin dependent kinase 7", "CDK7", "5q13.2", "ENSG00000134058", "", "Cyclin dependent kinases", true, "[true,false,false]", 1778, "gene with protein product", "NM_001799", "[]", "P50613" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7746961648860871356L, "kinesin family member 11", "KIF11", "10q23.33", "ENSG00000138160", "X85137", "Kinesins", true, "[true,false,false]", 6388, "gene with protein product", "NM_004523", "[]", "P52732" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3637348440751533328L, "Rac family small GTPase 1", "RAC1", "7p22.1", "ENSG00000136238", "AJ132695", "Rho family GTPases,Endogenous ligands", true, "[true,false,false]", 9801, "gene with protein product", "NM_018890", "[]", "P63000" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4196737465056089450L, "polo like kinase 1", "PLK1", "16p12.2", "ENSG00000166851", "", "", true, "[true,false,false]", 9077, "gene with protein product", "NM_005030", "[]", "P53350" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2400475259286814796L, "solute carrier family 2 member 1", "SLC2A1", "1p34.2", "ENSG00000117394", "K03195", "Solute carriers", true, "[true,false,false]", 11005, "gene with protein product", "NM_006516", "[]", "P11166" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2690523777657705330L, "phosphatidylinositol-4,5-bisphosphate 3-kinase catalytic subunit delta", "PIK3CD", "1p36.22", "ENSG00000171608", "", "Phosphatidylinositol 3-kinase subunits", true, "[true,false,false]", 8977, "gene with protein product", "NM_005026", "[\"phosphatidylinositol 3-kinase\",\"catalytic\",\"delta polypeptide\",\"phosphoinositide-3-kinase C\"]", "O00329" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -166838914670404711L, "C-C motif chemokine ligand 5", "CCL5", "17q12", "ENSG00000271503", "AF043341", "Chemokine ligands,Endogenous ligands", true, "[true,false,false]", 10632, "gene with protein product", "NM_002985", "[\"T-cell specific protein p288\",\"T-cell specific RANTES protein\",\"SIS-delta\",\"regulated upon activation\",\"normally T-expressed\",\"and presumably secreted\",\"beta-chemokine RANTES\",\"small inducible cytokine subfamily A (Cys-Cys)\",\"member 5\"]", "P13501" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3080343669100651568L, "KIT proto-oncogene receptor tyrosine kinase", "KIT", "4q12", "ENSG00000157404", "S67773", "Immunoglobulin like domain containing,CD molecules,Receptor tyrosine kinases", true, "[true,false,false]", 6342, "gene with protein product", "NM_000222", "[\"mast/stem cell growth factor receptor Kit\"]", "P10721" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2820536956988273337L, "aurora kinase B", "AURKB", "17p13.1", "ENSG00000178999", "AF004022", "Protein phosphatase 1 regulatory subunits,Chromosomal passenger complex", true, "[true,false,false]", 11390, "gene with protein product", "NM_004217", "[\"aurora-B\",\"aurora-1\",\"protein phosphatase 1\",\"regulatory subunit 48\"]", "Q96GD4" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3145274452025931097L, "phosphoinositide-3-kinase regulatory subunit 1", "PIK3R1", "5q13.1", "ENSG00000145675", "M61906", "SH2 domain containing", true, "[true,false,false]", 8979, "gene with protein product", "NM_181504", "[\"phosphoinositide-3-kinase regulatory subunit alpha\"]", "P27986" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5081325371871701341L, "phospholipase C gamma 1", "PLCG1", "20q12", "ENSG00000124181", "M34667", "Phospholipases,Pleckstrin homology domain containing,SH2 domain containing,C2 domain containing phospholipases,EF-hand domain containing", true, "[true,false,false]", 9065, "gene with protein product", "NM_182811", "[]", "P19174" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7110064130466762890L, "integrin subunit alpha 2b", "ITGA2B", "17q21.31", "ENSG00000005961", "", "Integrin alpha subunits,CD molecules,Protein phosphatase 1 regulatory subunits", true, "[true,false,false]", 6138, "gene with protein product", "NM_000419", "[\"protein phosphatase 1\",\"regulatory subunit 93\",\"platelet glycoprotein IIb of IIb/IIIa complex\"]", "P08514" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7028841955294953643L, "ALK receptor tyrosine kinase", "ALK", "2p23.2-p23.1", "ENSG00000171094", "D45915", "CD molecules,Receptor tyrosine kinases", true, "[true,false,false]", 427, "gene with protein product", "NM_004304", "[]", "Q9UM73" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7775320514256731712L, "phospholipase C gamma 2", "PLCG2", "16q24.1", "ENSG00000197943", "", "Phospholipases,SH2 domain containing,C2 domain containing phospholipases", true, "[true,false,false]", 9066, "gene with protein product", "NM_002661", "[]", "P16885" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2296163120660145083L, "thyroid hormone receptor beta", "THRB", "3p24.2", "ENSG00000151090", "", "Nuclear hormone receptors", true, "[true,false,false]", 11799, "gene with protein product", "NM_000461", "[\"avian erythroblastic leukemia viral (v-erb-a) oncogene homolog 2\",\"oncogene ERBA2\",\"generalized resistance to thyroid hormone\",\"thyroid hormone receptor beta 1\"]", "P10828" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 266948322105602135L, "glutamate ionotropic receptor NMDA type subunit 2B", "GRIN2B", "12p13.1", "ENSG00000273079", "", "Glutamate ionotropic receptor NMDA type subunits", true, "[true,false,false]", 4586, "gene with protein product", "NM_000834", "[]", "Q13224" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7300851850477672131L, "CDC like kinase 2", "CLK2", "1q22", "ENSG00000176444", "L29218", "CDC like kinases", true, "[true,false,false]", 2069, "gene with protein product", "NM_003993", "[]", "P49760" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -108765601467626317L, "albumin", "ALB", "4q13.3", "ENSG00000163631", "V00494", "", true, "[true,false,false]", 399, "gene with protein product", "NM_000477", "[]", "P02768" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5046092238998303617L, "serine protease 8", "PRSS8", "16p11.2", "ENSG00000052344", "U33446", "Serine proteases", true, "[true,false,false]", 9491, "gene with protein product", "NM_002773", "[\"prostasin\"]", "Q16651" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3579127417806621264L, "calcium/calmodulin dependent protein kinase I", "CAMK1", "3p25.3", "ENSG00000134072", "L41816", "Calmodulin dependent protein kinases", true, "[true,false,false]", 1459, "gene with protein product", "NM_003656", "[]", "Q14012" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1962916074300918041L, "S100 calcium binding protein B", "S100B", "21q22.3", "ENSG00000160307", "M59488", "EF-hand domain containing,S100 calcium binding proteins", true, "[true,false,false]", 10500, "gene with protein product", "NM_006272", "[]", "P04271" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7080576442467452282L, "cyclin dependent kinase 4", "CDK4", "12q14.1", "ENSG00000135446", "M14505", "Cyclin dependent kinases", true, "[true,false,false]", 1773, "gene with protein product", "NM_000075", "[]", "P11802" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1835498613592835781L, "cystic fibrosis transmembrane conductance regulator", "CFTR", "7q31.2", "ENSG00000001626", "M28668", "Chloride channels, ATP-gated CFTR,ATP binding cassette subfamily C", true, "[true,false,false]", 1884, "gene with protein product", "NM_000492", "[\"ATP-binding cassette sub-family C\",\"member 7\"]", "P13569" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7310032848217484074L, "serpin family E member 1", "SERPINE1", "7q22.1", "ENSG00000106366", "M16006", "Serpin peptidase inhibitors", true, "[true,false,false]", 8583, "gene with protein product", "NM_000602", "[\"plasminogen activator inhibitor\",\"type I\"]", "P05121" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2888567970247837626L, "mitogen-activated protein kinase kinase kinase 14", "MAP3K14", "17q21.31", "ENSG00000006062", "Y10256", "Mitogen-activated protein kinase kinase kinases", true, "[true,false,false]", 6853, "gene with protein product", "NM_003954", "[\"serine/threonine protein-kinase\"]", "Q99558" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5446801401145374728L, "integrin subunit alpha L", "ITGAL", "16p11.2", "ENSG00000005844", "", "Integrin alpha subunits,CD molecules", true, "[true,false,false]", 6148, "gene with protein product", "NM_001114380", "[\"antigen CD11A (p180)\",\"lymphocyte function-associated antigen 1\",\"alpha polypeptide\"]", "P20701" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8128611538873217362L, "protein tyrosine phosphatase, non-receptor type 1", "PTPN1", "20q13.13", "ENSG00000196396", "", "Protein tyrosine phosphatases, non-receptor type", true, "[true,false,false]", 9642, "gene with protein product", "NM_001278618", "[]", "P18031" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5783770255334107633L, "protein tyrosine kinase 2 beta", "PTK2B", "8p21.2", "ENSG00000120899", "U33284", "Minor histocompatibility antigens,FERM domain containing,PTK2 family tyrosine kinases", true, "[true,false,false]", 9612, "gene with protein product", "NM_004103", "[]", "Q14289" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -591683670650865732L, "integrin subunit alpha 4", "ITGA4", "2q31.3", "ENSG00000115232", "", "Integrin alpha subunits,CD molecules", true, "[true,false,false]", 6140, "gene with protein product", "NM_000885", "[\"antigen CD49D\",\"alpha 4 subunit of VLA-4 receptor\"]", "P13612" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1652440062800680466L, "serpin family A member 6", "SERPINA6", "14q32.13", "ENSG00000170099", "J02943", "Serpin peptidase inhibitors", true, "[true,false,false]", 1540, "gene with protein product", "NM_001756", "[\"corticosteroid binding globulin\",\"transcortin\"]", "P08185" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6441835835985977300L, "purinergic receptor P2Y12", "P2RY12", "3q25.1", "ENSG00000169313", "AJ320495", "P2Y receptors", true, "[true,false,false]", 18124, "gene with protein product", "NM_022788", "[]", "Q9H244" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3082058075461304994L, "spermidine/spermine N1-acetyltransferase 1", "SAT1", "Xp22.11", "ENSG00000130066", "M55580", "GCN5 related N-acetyltransferases", true, "[true,false,false]", 10540, "gene with protein product", "NM_002970", "[\"diamine N-acetyltransferase 1\"]", "P21673" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8314211214314705306L, "sulfotransferase family 2A member 1", "SULT2A1", "19q13.33", "ENSG00000105398", "X70222", "Sulfotransferases, cytosolic", true, "[true,false,false]", 11458, "gene with protein product", "NM_003167", "[]", "Q06520" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1240338334706334942L, "Raf-1 proto-oncogene, serine/threonine kinase", "RAF1", "3p25.2", "ENSG00000132155", "X03484", "RAF family,Mitogen-activated protein kinase kinase kinases", true, "[true,false,false]", 9829, "gene with protein product", "NM_002880", "[\"C-Raf proto-oncogene\",\"serine/threonine kinase\"]", "P04049" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3486129873678327719L, "C-C motif chemokine ligand 2", "CCL2", "17q12", "ENSG00000108691", "BC009716", "Chemokine ligands,Endogenous ligands", true, "[true,false,false]", 10618, "gene with protein product", "NM_002982", "[\"monocyte chemotactic protein 1\",\"homologous to mouse Sig-je\",\"monocyte chemoattractant protein-1\",\"monocyte chemotactic and activating factor\",\"monocyte secretory protein JE\",\"small inducible cytokine subfamily A (Cys-Cys)\",\"member 2\"]", "P13500" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7248152018939117953L, "nuclear receptor binding SET domain protein 2", "NSD2", "4p16.3", "ENSG00000109685", "AF083386", "PHD finger proteins,SET domain containing,Lysine methyltransferases,PWWP domain containing", true, "[true,false,false]", 12766, "gene with protein product", "NM_133330", "[\"multiple myeloma SET domain containing protein\"]", "O96028" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5847597755706979002L, "phosphoenolpyruvate carboxykinase 1", "PCK1", "20q13.31", "ENSG00000124253", "", "", true, "[true,false,false]", 8724, "gene with protein product", "NM_002591", "[]", "P35558" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2164972350581657011L, "erb-b2 receptor tyrosine kinase 2", "ERBB2", "17q12", "ENSG00000141736", "X03363", "CD molecules,Minor histocompatibility antigens,Erb-b2 receptor tyrosine kinases", true, "[true,false,false]", 3430, "gene with protein product", "NM_004448", "[\"neuro/glioblastoma derived oncogene homolog\",\"human epidermal growth factor receptor 2\"]", "P04626" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -227517515587540569L, "endoplasmic reticulum aminopeptidase 1", "ERAP1", "5q15", "ENSG00000164307", "AB011097", "Minor histocompatibility antigens,M1 metallopeptidases,Aminopeptidases", true, "[true,false,false]", 18173, "gene with protein product", "NM_016442", "[\"aminopeptidase regulator of TNFR1 shedding\",\"adipocyte-derived leucine aminopeptidase\",\"puromycin-insensitive leucyl-specific aminopeptidase\"]", "Q9NZ08" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8282918897315613729L, "potassium voltage-gated channel subfamily J member 11", "KCNJ11", "11p15.1", "ENSG00000187486", "D50582", "Potassium voltage-gated channel subfamily J", true, "[true,false,false]", 6257, "gene with protein product", "NM_000525", "[\"ATP-sensitive inward rectifier potassium channel 11\"]", "Q14654" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8234529567906223232L, "nitric oxide synthase 2", "NOS2", "17q11.2", "ENSG00000007171", "U20141", "", true, "[true,false,false]", 7873, "gene with protein product", "NM_000625", "[]", "P35228" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6193952907229243795L, "thioredoxin reductase 1", "TXNRD1", "12q23.3", "ENSG00000198431", "", "Selenoproteins,Glutaredoxin domain containing", true, "[true,false,false]", 12437, "gene with protein product", "NM_003330", "[]", "Q16881" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7924795117474522259L, "cytochrome P450 family 27 subfamily A member 1", "CYP27A1", "2q35", "ENSG00000135929", "BC017044", "Cytochrome P450 family 27", true, "[true,false,false]", 2605, "gene with protein product", "NM_000784", "[\"cerebrotendinous xanthomatosis\"]", "Q02318" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6884465304149252135L, "hemoglobin subunit alpha 1", "HBA1", "16p13.3", "ENSG00000206172", "AF349571", "Hemoglobin subunits", true, "[true,false,false]", 4823, "gene with protein product", "NM_000558", "[]", "P69905" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2882068794292324800L, "Pim-2 proto-oncogene, serine/threonine kinase", "PIM2", "Xp11.23", "ENSG00000102096", "U77735", "", true, "[true,false,false]", 8987, "gene with protein product", "NM_006875", "[]", "Q9P1W9" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4047910237243904126L, "coagulation factor X", "F10", "13q34", "ENSG00000126218", "", "Gla domain containing", true, "[true,false,false]", 3528, "gene with protein product", "NM_000504", "[]", "P00742" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6694364658057075244L, "coagulation factor XI", "F11", "4q35.2", "ENSG00000088926", "M13142", "", true, "[true,false,false]", 3529, "gene with protein product", "NM_000128", "[\"plasma thromboplastin antecedent\"]", "P03951" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4074068617093194307L, "alcohol dehydrogenase 7 (class IV), mu or sigma polypeptide", "ADH7", "4q23", "ENSG00000196344", "X76342", "Alcohol dehydrogenases", true, "[true,false,false]", 256, "gene with protein product", "NM_000673", "[]", "P40394" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4856786093785805082L, "DNA polymerase theta", "POLQ", "3q13.33", "ENSG00000051341", "AF052573", "DNA polymerases", true, "[true,false,false]", 9186, "gene with protein product", "NM_199420", "[]", "O75417" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6644534177223853402L, "BCL2 associated X, apoptosis regulator", "BAX", "19q13.33", "ENSG00000087088", "", "BCL2 family", true, "[true,false,false]", 959, "gene with protein product", "NM_138763", "[]", "Q07812" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3027321970642692182L, "carbonic anhydrase 9", "CA9", "9p13.3", "ENSG00000107159", "X66839", "Carbonic anhydrases", true, "[true,false,false]", 1383, "gene with protein product", "NM_001216", "[\"carbonic dehydratase\",\"RCC-associated protein G250\"]", "Q16790" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4855687658952291570L, "cytochrome P450 family 1 subfamily A member 2", "CYP1A2", "15q24.1", "ENSG00000140505", "AF182274", "Cytochrome P450 family 1", true, "[true,false,false]", 2596, "gene with protein product", "NM_000761", "[]", "P05177" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8202853664092594543L, "interleukin 1 receptor associated kinase 1", "IRAK1", "Xq28", "ENSG00000184216", "L76191", "", true, "[true,false,false]", 6112, "gene with protein product", "NM_001025242", "[]", "P51617" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6122269893740583545L, "carbonic anhydrase 1", "CA1", "8q21.2", "ENSG00000133742", "M33987", "Carbonic anhydrases", true, "[true,false,false]", 1368, "gene with protein product", "NM_001738", "[]", "P00915" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2998541208038749011L, "checkpoint kinase 1", "CHEK1", "11q24.2", "ENSG00000149554", "AF016582", "", true, "[true,false,false]", 1925, "gene with protein product", "NM_001274", "[]", "O14757" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6416581235290523177L, "coagulation factor IX", "F9", "Xq27.1", "ENSG00000101981", "M11309", "Gla domain containing", true, "[true,false,false]", 3551, "gene with protein product", "NM_000133", "[\"Factor IX\",\"plasma thromboplastic component\",\"Christmas disease\",\"hemophilia B\"]", "P00740" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2096362753557469735L, "checkpoint kinase 2", "CHEK2", "22q12.1", "ENSG00000183765", "AF086904", "", true, "[true,false,false]", 16627, "gene with protein product", "NM_001005735", "[]", "O96017" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2941780911780750327L, "carbonic anhydrase 3", "CA3", "8q21.2", "ENSG00000164879", "AJ006473", "Carbonic anhydrases", true, "[true,false,false]", 1374, "gene with protein product", "NM_005181", "[]", "P07451" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8920140813000375529L, "carbonic anhydrase 2", "CA2", "8q21.2", "ENSG00000104267", "J03037", "Carbonic anhydrases", true, "[true,false,false]", 1373, "gene with protein product", "NM_000067", "[]", "P00918" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8882406792480976448L, "carbonic anhydrase 4", "CA4", "17q23.1", "ENSG00000167434", "L10955", "Carbonic anhydrases", true, "[true,false,false]", 1375, "gene with protein product", "NM_000717", "[]", "P22748" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1298358004011320323L, "carboxylesterase 1", "CES1", "16q12.2", "ENSG00000198848", "BC012418", "Carboxylesterases", true, "[true,false,false]", 1863, "gene with protein product", "NM_001266", "[\"human monocyte/macrophage serine esterase 1\"]", "P23141" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4808289748145464505L, "carbonic anhydrase 7", "CA7", "16q22.1", "ENSG00000168748", "", "Carbonic anhydrases", true, "[true,false,false]", 1381, "gene with protein product", "NM_001014435", "[]", "P43166" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3286014952854004730L, "erb-b2 receptor tyrosine kinase 3", "ERBB3", "12q13.2", "ENSG00000065361", "M34309", "Erb-b2 receptor tyrosine kinases", true, "[true,false,false]", 3431, "gene with protein product", "NM_001982", "[\"human epidermal growth factor receptor 3\"]", "P21860" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3165318530856244256L, "erb-b2 receptor tyrosine kinase 4", "ERBB4", "2q34", "ENSG00000178568", "L07868", "Erb-b2 receptor tyrosine kinases", true, "[true,false,false]", 3432, "gene with protein product", "NM_001042599", "[\"human epidermal growth factor receptor 4\"]", "Q15303" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4774323977254777348L, "collagen type II alpha 1 chain", "COL2A1", "12q13.11", "ENSG00000139219", "X16468", "Collagens", true, "[true,false,false]", 2200, "gene with protein product", "NM_001844", "[]", "P02458" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2050545138202642574L, "major histocompatibility complex, class I, A", "HLA-A", "6p22.1", "ENSG00000206503", "D32129", "C1-set domain containing,Histocompatibility complex", true, "[true,false,false]", 4931, "gene with protein product", "NM_002116", "[]", "P01891" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8488393433250885210L, "NRAS proto-oncogene, GTPase", "NRAS", "1p13.2", "ENSG00000213281", "BC005219", "RAS type GTPase family", true, "[true,false,false]", 7989, "gene with protein product", "NM_002524", "[]", "P01111" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2059476425741387707L, "B-Raf proto-oncogene, serine/threonine kinase", "BRAF", "7q34", "ENSG00000157764", "M95712", "RAF family,Mitogen-activated protein kinase kinase kinases", true, "[true,false,false]", 1097, "gene with protein product", "NM_004333", "[]", "P15056" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4871066599161628283L, "actin beta", "ACTB", "7p22.1", "ENSG00000075624", "M28424", "Actins,PBAF complex,BAF complex,GBAF complex", true, "[true,false,false]", 132, "gene with protein product", "NM_001101", "[\"Î²-actin\"]", "P60709" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 552817079677848373L, "heat shock protein family D (Hsp60) member 1", "HSPD1", "2q33.1", "ENSG00000144381", "M34664", "Chaperonins", true, "[true,false,false]", 5261, "gene with protein product", "NM_002156", "[]", "P10809" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5577364513658075151L, "protein tyrosine phosphatase, receptor type G", "PTPRG", "3p14.2", "ENSG00000144724", "L09247", "Fibronectin type III domain containing,Protein tyrosine phosphatases, receptor type", true, "[true,false,false]", 9671, "gene with protein product", "NM_002841", "[]", "P23470" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7833691892390660488L, "glutathione S-transferase pi 1", "GSTP1", "11q13.2", "ENSG00000084207", "U12472", "Soluble glutathione S-transferases", true, "[true,false,false]", 4638, "gene with protein product", "NM_000852", "[]", "P09211" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1523609009458026692L, "complement factor B", "CFB", "6p21.33", "ENSG00000243649", "L15702", "Sushi domain containing,Complement system activation components", true, "[true,false,false]", 1037, "gene with protein product", "NM_001710", "[]", "P00751" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3114185400287924179L, "mitogen-activated protein kinase 12", "MAPK12", "22q13.33", "ENSG00000188130", "U66243", "Mitogen-activated protein kinases", true, "[true,false,false]", 6874, "gene with protein product", "NM_002969", "[]", "P53778" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8439368411212131505L, "heat shock protein 90 alpha family class B member 1", "HSP90AB1", "6p21.1", "ENSG00000096384", "AF275719", "Heat shock 90kDa proteins", true, "[true,false,false]", 5258, "gene with protein product", "NM_007355", "[]", "P08238" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7429245781809420632L, "alanyl aminopeptidase, membrane", "ANPEP", "15q26.1", "ENSG00000166825", "M22324", "CD molecules,M1 metallopeptidases,Aminopeptidases", true, "[true,false,false]", 500, "gene with protein product", "NM_001150", "[\"aminopeptidase N\",\"aminopeptidase M\",\"microsomal aminopeptidase\",\"membrane alanyl aminopeptidase\"]", "P15144" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 580762822894835590L, "heat shock protein 90 alpha family class A member 1", "HSP90AA1", "14q32.31", "ENSG00000080824", "M27024", "Heat shock 90kDa proteins", true, "[true,false,false]", 5253, "gene with protein product", "NM_005348", "[]", "P07900" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8029969379815858125L, "natriuretic peptide A", "NPPA", "1p36.22", "ENSG00000175206", "BC005893", "Endogenous ligands", true, "[true,false,false]", 7939, "gene with protein product", "NM_006172", "[]", "P01160" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 413160924379259371L, "BCL2 like 1", "BCL2L1", "20q11.21", "ENSG00000171552", "Z23115", "Protein phosphatase 1 regulatory subunits,BCL2 family", true, "[true,false,false]", 992, "gene with protein product", "NM_138578", "[\"protein phosphatase 1\",\"regulatory subunit 52\"]", "Q07817" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -9111210136835967353L, "catechol-O-methyltransferase", "COMT", "22q11.21", "ENSG00000093010", "", "Seven-beta-strand methyltransferase motif containing", true, "[true,false,false]", 2228, "gene with protein product", "NM_000754", "[]", "P21964" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3391048516841809013L, "aldo-keto reductase family 1 member B", "AKR1B1", "7q33", "ENSG00000085662", "J04795", "Aldo-keto reductases", true, "[true,false,false]", 381, "gene with protein product", "NM_001628", "[\"aldose reductase\"]", "P15121" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1198815245324831882L, "hypoxanthine phosphoribosyltransferase 1", "HPRT1", "Xq26.2-q26.3", "ENSG00000165704", "M26434", "", true, "[true,false,false]", 5157, "gene with protein product", "NM_000194", "[\"Lesch-Nyhan syndrome\"]", "P00492" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -670717245265312635L, "arachidonate 5-lipoxygenase activating protein", "ALOX5AP", "13q12.3", "ENSG00000132965", "AH001462", "", true, "[true,false,false]", 436, "gene with protein product", "NM_001629", "[\"five-lipoxygenase activating protein\",\"MK-886-binding protein\"]", "P20292" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 864388842414647706L, "BCL2, apoptosis regulator", "BCL2", "18q21.33", "ENSG00000171791", "M14745", "Protein phosphatase 1 regulatory subunits,BCL2 family", true, "[true,false,false]", 990, "gene with protein product", "NM_000633", "[\"protein phosphatase 1\",\"regulatory subunit 50\"]", "P10415" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8115463001070408666L, "lysine acetyltransferase 8", "KAT8", "16p11.2", "ENSG00000103510", "AF217501", "MSL histone acetyltransferase complex,NSL histone acetyltransferase complex,Zinc fingers C2HC-type,MYST type domain containing lysine acetyltransferases", true, "[true,false,false]", 17933, "gene with protein product", "NM_032188", "[]", "Q9H7Z6" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8991575294890443428L, "mitogen-activated protein kinase 11", "MAPK11", "22q13.33", "ENSG00000185386", "Y14440", "Mitogen-activated protein kinases", true, "[true,false,false]", 6873, "gene with protein product", "NM_002751", "[]", "Q15759" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8742174003728770588L, "farnesyl diphosphate synthase", "FDPS", "1q22", "ENSG00000160752", "J05262", "", true, "[true,false,false]", 3631, "gene with protein product", "NM_002004", "[\"farnesyl pyrophosphate synthetase\",\"dimethylallyltranstransferase\",\"geranyltranstransferase\"]", "P14324" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8538324753306470562L, "platelet derived growth factor receptor alpha", "PDGFRA", "4q12", "ENSG00000134853", "D50001", "I-set domain containing,CD molecules,Receptor tyrosine kinases", true, "[true,false,false]", 8803, "gene with protein product", "NM_006206", "[]", "P16234" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1541553470328877920L, "solute carrier family 1 member 3", "SLC1A3", "5p13.2", "ENSG00000079215", "", "Solute carriers", true, "[true,false,false]", 10941, "gene with protein product", "NM_004172", "[\"glutamate transporter variant EAAT1ex9skip\"]", "P43003" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4178025057816367392L, "phosphodiesterase 3B", "PDE3B", "11p15.2", "ENSG00000152270", "U38178", "Phosphodiesterases", true, "[true,false,false]", 8779, "gene with protein product", "NM_000922", "[]", "Q13370" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5767965696690967919L, "farnesyltransferase, CAAX box, beta", "FNTB", "14q23.3", "ENSG00000257365", "", "", true, "[true,false,false]", 3785, "gene with protein product", "NM_002028", "[]", "P49356" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4723870892598290853L, "dual specificity phosphatase 1", "DUSP1", "5q35.1", "ENSG00000120129", "X68277", "MAP kinase phosphatases", true, "[true,false,false]", 3064, "gene with protein product", "NM_004417", "[]", "P28562" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8969815508280037039L, "ROS proto-oncogene 1, receptor tyrosine kinase", "ROS1", "6q22.1", "ENSG00000047936", "M13599", "Fibronectin type III domain containing,Receptor tyrosine kinases", true, "[true,false,false]", 10261, "gene with protein product", "NM_002944", "[]", "P08922" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6519456723159858717L, "aurora kinase A", "AURKA", "20q13.2", "ENSG00000087586", "BC001280", "Protein phosphatase 1 regulatory subunits", true, "[true,false,false]", 11393, "gene with protein product", "NM_003600", "[\"protein phosphatase 1\",\"regulatory subunit 47\",\"Aurora-A kinase\"]", "O14965" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8256052442709687961L, "Bruton tyrosine kinase", "BTK", "Xq22.1", "ENSG00000010671", "AK057105", "Tec family tyrosine kinases,Pleckstrin homology domain containing,SH2 domain containing", true, "[true,false,false]", 1133, "gene with protein product", "NM_000061", "[\"Bruton's tyrosine kinase\"]", "Q06187" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6946266493517979349L, "cytochrome P450 family 11 subfamily B member 2", "CYP11B2", "8q24.3", "ENSG00000179142", "X54741", "Cytochrome P450 family 11", true, "[true,false,false]", 2592, "gene with protein product", "NM_000498", "[\"steroid 11-beta-monooxygenase\"]", "P19099" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3176824505865931761L, "mitogen-activated protein kinase 14", "MAPK14", "6p21.31", "ENSG00000112062", "L35263", "Mitogen-activated protein kinases", true, "[true,false,false]", 6876, "gene with protein product", "NM_001315", "[\"p38 MAP kinase\"]", "Q16539" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5393644031675907400L, "purine nucleoside phosphorylase", "PNP", "14q11.2", "ENSG00000198805", "", "", true, "[true,false,false]", 7892, "gene with protein product", "NM_000270.2", "[]", "P00491" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5579014919104266194L, "integrin linked kinase", "ILK", "11p15.4", "ENSG00000166333", "U40282", "Ankyrin repeat domain containing", true, "[true,false,false]", 6040, "gene with protein product", "NM_004517", "[]", "Q13418" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -905599235603354615L, "solute carrier family 6 member 4", "SLC6A4", "17q11.2", "ENSG00000108576", "L05568", "Solute carriers", true, "[true,false,false]", 11050, "gene with protein product", "NM_001045", "[\"serotonin transporter 1\"]", "P31645" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5049699003963435050L, "kallikrein related peptidase 2", "KLK2", "19q13.33", "ENSG00000167751", "M18157", "Kallikreins", true, "[true,false,false]", 6363, "gene with protein product", "NM_005551.3", "[]", "P20151" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7874641701777122698L, "glucosylceramidase beta", "GBA", "1q22", "ENSG00000177628", "M19285", "Glycoside hydrolases", true, "[true,false,false]", 4177, "gene with protein product", "NM_000157", "[]", "P04062" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2196486239926414644L, "fatty acid binding protein 4", "FABP4", "8q21.13", "ENSG00000170323", "J02874", "Fatty acid binding protein family", true, "[true,false,false]", 3559, "gene with protein product", "NM_001442", "[\"adipocyte fatty acid binding protein\"]", "P15090" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6794221876500488009L, "fatty acid binding protein 2", "FABP2", "4q26", "ENSG00000145384", "J03465", "Fatty acid binding protein family", true, "[true,false,false]", 3556, "gene with protein product", "NM_000134", "[]", "P12104" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5531825676035196783L, "fatty acid binding protein 3", "FABP3", "1p35.2", "ENSG00000121769", "U57623", "Fatty acid binding protein family", true, "[true,false,false]", 3557, "gene with protein product", "NM_004102", "[\"mammary-derived growth inhibitor\"]", "P05413" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -9174313527596187483L, "fatty acid binding protein 1", "FABP1", "2p11.2", "ENSG00000163586", "M10617", "Fatty acid binding protein family", true, "[true,false,false]", 3555, "gene with protein product", "NM_001443", "[]", "P07148" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7518018316926652501L, "membrane metalloendopeptidase", "MME", "3q25.2", "ENSG00000196549", "", "CD molecules,M13 metallopeptidases", true, "[true,false,false]", 7154, "gene with protein product", "NM_000902", "[\"neutral endopeptidase\",\"enkephalinase\",\"neprilysin\"]", "P08473" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8816185447602660839L, "branched chain amino acid transaminase 1", "BCAT1", "12p12.1", "ENSG00000060982", "", "", true, "[true,false,false]", 976, "gene with protein product", "NM_005504", "[]", "P54687" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3501430381557928791L, "coagulation factor II thrombin receptor", "F2R", "5q13.3", "ENSG00000181104", "M62424", "F2R receptors", true, "[true,false,false]", 3537, "gene with protein product", "NM_001992", "[\"protease activated receptor 1\"]", "P25116" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2719515960030308739L, "apelin receptor", "APLNR", "11q12.1", "ENSG00000134817", "U03642", "Peptide receptors", true, "[true,false,false]", 339, "gene with protein product", "NM_005161", "[\"APJ (apelin) receptor\"]", "P35414" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -652404531438348698L, "cholinergic receptor nicotinic alpha 4 subunit", "CHRNA4", "20q13.33", "ENSG00000101204", "", "Cholinergic receptors nicotinic subunits", true, "[true,false,false]", 1958, "gene with protein product", "NM_000744", "[\"acetylcholine receptor\",\"nicotinic\",\"alpha 4 (neuronal)\"]", "P43681" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3279078642072290332L, "poly(ADP-ribose) polymerase 1", "PARP1", "1q42.12", "ENSG00000143799", "BC037545", "Zinc fingers PARP-type,Zinc fingers,Poly(ADP-ribose) polymerases", true, "[true,false,false]", 270, "gene with protein product", "NM_001618", "[]", "P09874" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8899828626987360145L, "complement C5a receptor 1", "C5AR1", "19q13.32", "ENSG00000197405", "", "Complement component GPCRs,CD molecules,Complement system regulators and receptors", true, "[true,false,false]", 1338, "gene with protein product", "NM_001736", "[]", "P21730" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4933218803741291348L, "betaine--homocysteine S-methyltransferase", "BHMT", "5q14.1", "ENSG00000145692", "BC012616", "", true, "[true,false,false]", 1047, "gene with protein product", "NM_001713", "[\"betaine homocysteine methyltransferase\"]", "Q93088" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1868497937939581313L, "cholinergic receptor nicotinic alpha 3 subunit", "CHRNA3", "15q25.1", "ENSG00000080644", "", "Cholinergic receptors nicotinic subunits", true, "[true,false,false]", 1957, "gene with protein product", "NM_000743", "[\"acetylcholine receptor\",\"nicotinic\",\"alpha 3 (neuronal)\"]", "P32297" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3706403947399110904L, "activin A receptor type 2B", "ACVR2B", "3p22.2", "ENSG00000114739", "X77533", "Type 2 receptor serine/threonine kinases", true, "[true,false,false]", 174, "gene with protein product", "NM_001106", "[]", "Q13705" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2367107532765053409L, "cytochrome P450 family 1 subfamily A member 1", "CYP1A1", "15q24.1", "ENSG00000140465", "BC023019", "Cytochrome P450 family 1", true, "[true,false,false]", 2595, "gene with protein product", "NM_000499", "[]", "P04798" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8443682161072404958L, "FKBP prolyl isomerase 1A", "FKBP1A", "20p13", "ENSG00000088832", "M92423", "FKBP prolyl isomerases", true, "[true,false,false]", 3711, "gene with protein product", "NM_000801", "[\"calstabin 1\"]", "P62942" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1875358783136948836L, "centromere protein E", "CENPE", "4q24", "ENSG00000138778", "Z15005", "Protein phosphatase 1 regulatory subunits,Kinesins", true, "[true,false,false]", 1856, "gene with protein product", "NM_001286734", "[\"protein phosphatase 1\",\"regulatory subunit 61\"]", "Q02224" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1096905976741962589L, "ABO, alpha 1-3-N-acetylgalactosaminyltransferase and alpha 1-3-galactosyltransferase", "ABO", "9q34.2", "ENSG00000175164", "AF134415", "Glycosyltransferase family 6,Blood group antigens", true, "[true,false,false]", 79, "gene with protein product", "NM_020469", "[]", "P16442" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -836655376402262505L, "protein C, inactivator of coagulation factors Va and VIIIa", "PROC", "2q14.3", "ENSG00000115718", "X02750", "Gla domain containing,Endogenous ligands", true, "[true,false,false]", 9451, "gene with protein product", "NM_000312", "[\"prepro-protein C\"]", "P04070" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 319378812624435227L, "hydroxysteroid 11-beta dehydrogenase 1", "HSD11B1", "1q32.2", "ENSG00000117594", "BC012593", "Short chain dehydrogenase/reductase superfamily", true, "[true,false,false]", 5208, "gene with protein product", "NM_005525", "[\"short chain dehydrogenase/reductase family 26C\",\"member 1\"]", "P28845" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2178381005042933731L, "mitogen-activated protein kinase kinase 1", "MAP2K1", "15q22.31", "ENSG00000169032", "L11284", "Mitogen-activated protein kinase kinases", true, "[true,false,false]", 6840, "gene with protein product", "NM_002755", "[]", "Q02750" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3942096020644265609L, "ATP binding cassette subfamily B member 1", "ABCB1", "7q21.12", "ENSG00000085563", "M14758", "CD molecules,ATP binding cassette subfamily B", true, "[true,false,false]", 40, "gene with protein product", "NM_000927", "[\"multidrug resistance protein 1\"]", "P08183" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2706602557455485085L, "heat shock protein family A (Hsp70) member 5", "HSPA5", "9q33.3", "ENSG00000044574", "", "Heat shock 70kDa proteins", true, "[true,false,false]", 5238, "gene with protein product", "NM_005347", "[\"glucose-regulated protein\",\"78kDa\"]", "P11021" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -64096387862235902L, "aminolevulinate dehydratase", "ALAD", "9q32", "ENSG00000148218", "M13928", "", true, "[true,false,false]", 395, "gene with protein product", "NM_001003945", "[\"porphobilinogen synthase\"]", "P13716" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5055223213953354960L, "phosphodiesterase 4D", "PDE4D", "5q11.2-q12.1", "ENSG00000113448", "", "Phosphodiesterases", true, "[true,false,false]", 8783, "gene with protein product", "NM_001104631", "[\"phosphodiesterase E3 dunce homolog (Drosophila)\",\"cAMP-specific 3'\",\"5'-cyclic phosphodiesterase 4D\"]", "Q08499" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 466418287210643955L, "phosphodiesterase 4B", "PDE4B", "1p31.3", "ENSG00000184588", "L20971", "Phosphodiesterases", true, "[true,false,false]", 8781, "gene with protein product", "NM_002600", "[\"phosphodiesterase E4 dunce homolog (Drosophila)\",\"cAMP-specific 3'\",\"5'-cyclic phosphodiesterase 4B\"]", "Q07343" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5886027972297370267L, "calcium/calmodulin dependent protein kinase II beta", "CAMK2B", "7p13", "ENSG00000058404", "U50358", "Calmodulin dependent protein kinases", true, "[true,false,false]", 1461, "gene with protein product", "NM_172084", "[\"CaM-kinase II beta chain\",\"calcium/calmodulin-dependent protein kinase type II beta chain\",\"CaM kinase II beta subunit\",\"proline rich calmodulin-dependent protein kinase\"]", "Q13554" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7020633545744679155L, "phosphodiesterase 4A", "PDE4A", "19p13.2", "ENSG00000065989", "", "Phosphodiesterases", true, "[true,false,false]", 8780, "gene with protein product", "NM_001111307", "[\"phosphodiesterase E2 dunce homolog (Drosophila)\"]", "P27815" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6407724753413663221L, "N-acetylated alpha-linked acidic dipeptidase 2", "NAALAD2", "11q14.3", "ENSG00000077616", "AJ012370", "", true, "[true,false,false]", 14526, "gene with protein product", "NM_005467", "[\"glutamate carboxypeptidase III\"]", "Q9Y3Q0" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8185965384736935547L, "folate hydrolase 1", "FOLH1", "11p11.12", "ENSG00000086205", "M99487", "", true, "[true,false,false]", 3788, "gene with protein product", "NM_004476", "[\"glutamate carboxylase II\",\"glutamate carboxypeptidase 2\"]", "Q04609" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -602500104778997899L, "EPH receptor A3", "EPHA3", "3p11.1", "ENSG00000044524", "M83941", "Sterile alpha motif domain containing,Fibronectin type III domain containing,EPH receptors", true, "[true,false,false]", 3387, "gene with protein product", "NM_005233", "[]", "P29320" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5616024887144011202L, "fatty acid synthase", "FASN", "17q25.3", "ENSG00000169710", "U26644", "Short chain dehydrogenase/reductase superfamily,Seven-beta-strand methyltransferase motif containing", true, "[true,false,false]", 3594, "gene with protein product", "NM_004104", "[\"short chain dehydrogenase/reductase family 27X\",\"member 1\"]", "P49327" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4154543005689276688L, "galectin 3", "LGALS3", "14q22.3", "ENSG00000131981", "M64303", "Galectins,Endogenous ligands", true, "[true,false,false]", 6563, "gene with protein product", "NM_002306", "[\"advanced glycation end-product receptor 3\"]", "P17931" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -306658287103020408L, "insulin degrading enzyme", "IDE", "10q23.33", "ENSG00000119912", "M21188", "M16 metallopeptidases", true, "[true,false,false]", 5381, "gene with protein product", "NM_004969", "[\"insulysin\"]", "P14735" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2839488711434410816L, "epoxide hydrolase 2", "EPHX2", "8p21.2-p21.1", "ENSG00000120915", "L05779", "HAD Asp-based non-protein phosphatases", true, "[true,false,false]", 3402, "gene with protein product", "NM_001979", "[]", "P34913" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7626791815591738653L, "carbonic anhydrase 13", "CA13", "8q21.2", "ENSG00000185015", "BC052602", "Carbonic anhydrases", true, "[true,false,false]", 14914, "gene with protein product", "NM_198584", "[]", "Q8N1Q1" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7271386503413621600L, "glutathione S-transferase omega 1", "GSTO1", "10q25.1", "ENSG00000148834", "AF212303", "Soluble glutathione S-transferases", true, "[true,false,false]", 13312, "gene with protein product", "NM_004832", "[]", "P78417" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7869253853618088139L, "glutathione S-transferase omega 2", "GSTO2", "10q25.1", "ENSG00000065621", "AY191318", "Soluble glutathione S-transferases", true, "[true,false,false]", 23064, "gene with protein product", "NM_183239", "[]", "Q9H4Y5" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5538299065142700633L, "MET proto-oncogene, receptor tyrosine kinase", "MET", "7q31", "ENSG00000105976", "M35073", "Deafness associated genes,Receptor tyrosine kinases", true, "[true,false,false]", 7029, "gene with protein product", "NM_000245", "[\"hepatocyte growth factor receptor\"]", "P08581" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4690596245772934019L, "myoglobin", "MB", "22q12.3", "ENSG00000198125", "", "", true, "[true,false,false]", 6915, "gene with protein product", "NM_203377", "[]", "P02144" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2242414330299779124L, "parathyroid hormone 1 receptor", "PTH1R", "3p21.31", "ENSG00000160801", "", "Parathyroid hormone receptors", true, "[true,false,false]", 9608, "gene with protein product", "NM_000316", "[]", "Q03431" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8505581847414489808L, "carbonic anhydrase 14", "CA14", "1q21.2", "ENSG00000118298", "AB025904", "Carbonic anhydrases", true, "[true,false,false]", 1372, "gene with protein product", "NM_012113", "[]", "Q9ULX7" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3741045317082072732L, "bone morphogenetic protein receptor type 2", "BMPR2", "2q33.1-q33.2", "ENSG00000204217", "Z48923", "Type 2 receptor serine/threonine kinases", true, "[true,false,false]", 1078, "gene with protein product", "NM_001204", "[]", "Q13873" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3526653529522139666L, "natriuretic peptide receptor 3", "NPR3", "5p13.3", "ENSG00000113389", "", "DENN/MADD domain containing", true, "[true,false,false]", 7945, "gene with protein product", "NM_000908", "[\"guanylate cyclase C\"]", "P17342" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -968323116932171173L, "fms related tyrosine kinase 1", "FLT1", "13q12.3", "ENSG00000102755", "AF063657", "Immunoglobulin like domain containing,I-set domain containing,Receptor tyrosine kinases", true, "[true,false,false]", 3763, "gene with protein product", "NM_002019", "[\"vascular endothelial growth factor receptor 1\",\"vascular permeability factor receptor\"]", "P17948" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4113826880462165289L, "peptidase D", "PEPD", "19q13.11", "ENSG00000124299", "BC015027", "", true, "[true,false,false]", 8840, "gene with protein product", "NM_000285", "[\"prolidase\",\"Xaa-Pro dipeptidase\"]", "P12955" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5434750034275688544L, "heat shock protein family A (Hsp70) member 2", "HSPA2", "14q23.3", "ENSG00000126803", "L26336", "Heat shock 70kDa proteins", true, "[true,false,false]", 5235, "gene with protein product", "NM_021979", "[]", "P54652" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4038938137687233986L, "activin A receptor type 1", "ACVR1", "2q24.1", "ENSG00000115170", "", "Type 1 receptor serine/threonine kinases", true, "[true,false,false]", 171, "gene with protein product", "NM_001105", "[]", "Q04771" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3223603088932536141L, "heat shock protein family A (Hsp70) member 8", "HSPA8", "11q24.1", "ENSG00000109971", "Y00371", "Spliceosomal P complex,Heat shock 70kDa proteins,Spliceosomal C complex", true, "[true,false,false]", 5241, "gene with protein product", "NM_006597", "[]", "P11142" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5708583372417341622L, "synaptosome associated protein 25", "SNAP25", "20p12.2", "ENSG00000132639", "", "SNAREs", true, "[true,false,false]", 11132, "gene with protein product", "NM_130811", "[\"resistance to inhibitors of cholinesterase 4 homolog\"]", "P60880" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1533829891749974269L, "aldehyde dehydrogenase 2 family member", "ALDH2", "12q24.12", "ENSG00000111275", "M26760", "Aldehyde dehydrogenases", true, "[true,false,false]", 404, "gene with protein product", "NM_000690", "[]", "P05091" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1860378687312062720L, "retinol binding protein 4", "RBP4", "10q23.33", "ENSG00000138207", "BC020633", "Lipocalins", true, "[true,false,false]", 9922, "gene with protein product", "NM_006744", "[]", "P02753" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8672610739681665592L, "baculoviral IAP repeat containing 2", "BIRC2", "11q22.2", "ENSG00000110330", "L49431", "Baculoviral IAP repeat containing,Ring finger proteins,Caspase recruitment domain containing", true, "[true,false,false]", 590, "gene with protein product", "NM_001166", "[\"NFR2-TRAF signalling complex protein\",\"apoptosis inhibitor 1\"]", "Q13490" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8217599466527781050L, "alcohol dehydrogenase 1C (class I), gamma polypeptide", "ADH1C", "4q23", "ENSG00000248144", "M12272", "Alcohol dehydrogenases", true, "[true,false,false]", 251, "gene with protein product", "NM_000669", "[]", "P00326" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7286442021231424070L, "baculoviral IAP repeat containing 3", "BIRC3", "11q22.2", "ENSG00000023445", "L49432", "Baculoviral IAP repeat containing,Ring finger proteins,Caspase recruitment domain containing", true, "[true,false,false]", 591, "gene with protein product", "NM_001165", "[\"apoptosis inhibitor 2\",\"TNFR2-TRAF signaling complex protein\",\"mammalian IAP homolog C\",\"inhibitor of apoptosis protein 1\"]", "Q13489" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2662126199465510133L, "alcohol dehydrogenase 1B (class I), beta polypeptide", "ADH1B", "4q23", "ENSG00000196616", "AF153821", "Alcohol dehydrogenases", true, "[true,false,false]", 250, "gene with protein product", "NM_000668", "[]", "P00325" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3017416383587474580L, "cathepsin G", "CTSG", "14q12", "ENSG00000100448", "M16117", "Cathepsins,Endogenous ligands,Granule associated serine proteases of immune defence", true, "[true,false,false]", 2532, "gene with protein product", "NM_001911", "[]", "P08311" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7458056271654969368L, "protein kinase cGMP-dependent 1", "PRKG1", "10q11.23-q21.1", "ENSG00000185532", "", "AGC family kinases", true, "[true,false,false]", 9414, "gene with protein product", "NM_001098512", "[]", "Q13976" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7515564671800847140L, "baculoviral IAP repeat containing 5", "BIRC5", "17q25.3", "ENSG00000089685", "U75285", "Baculoviral IAP repeat containing,Chromosomal passenger complex", true, "[true,false,false]", 593, "gene with protein product", "NM_001168", "[\"survivin variant 3 alpha\"]", "O15392" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6595471962186604754L, "matrix metallopeptidase 13", "MMP13", "11q22.2", "ENSG00000137745", "X75308", "M10 matrix metallopeptidases,Endogenous ligands", true, "[true,false,false]", 7159, "gene with protein product", "NM_002427", "[\"collagenase 3\"]", "P45452" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5046769656126260384L, "matrix metallopeptidase 12", "MMP12", "11q22.2", "ENSG00000262406", "L23808", "M10 matrix metallopeptidases", true, "[true,false,false]", 7158, "gene with protein product", "NM_002426", "[\"macrophage elastase\"]", "P39900" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4306993936190403112L, "matrix metallopeptidase 10", "MMP10", "11q22.2", "ENSG00000166670", "X07820", "M10 matrix metallopeptidases", true, "[true,false,false]", 7156, "gene with protein product", "NM_002425", "[]", "P09238" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 581978828847249191L, "cyclin dependent kinase 5", "CDK5", "7q36.1", "ENSG00000164885", "X66364", "Cyclin dependent kinases", true, "[true,false,false]", 1774, "gene with protein product", "NM_001164410", "[]", "Q00535" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5996653262732456743L, "histone deacetylase 2", "HDAC2", "6q21", "ENSG00000196591", "U31814", "NuRD complex,Histone deacetylases, class I,EMSY complex,SIN3 histone deacetylase complex subunits", true, "[true,false,false]", 4853, "gene with protein product", "NM_001527", "[]", "Q92769" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -297014388601758531L, "histone deacetylase 1", "HDAC1", "1p35.2-p35.1", "ENSG00000116478", "D50405", "NuRD complex,Histone deacetylases, class I,EMSY complex,SIN3 histone deacetylase complex subunits", true, "[true,false,false]", 4852, "gene with protein product", "NM_004964", "[]", "Q13547" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -677034654539159249L, "adrenomedullin", "ADM", "11p15.4", "ENSG00000148926", "D14874", "Endogenous ligands", true, "[true,false,false]", 259, "gene with protein product", "NM_001124", "[]", "P35318" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2702269034664917480L, "EPH receptor B4", "EPHB4", "7q22.1", "ENSG00000196411", "AY056047", "Sterile alpha motif domain containing,Fibronectin type III domain containing,EPH receptors", true, "[true,false,false]", 3395, "gene with protein product", "NM_004444", "[]", "P54760" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3276207780796304024L, "histone deacetylase 6", "HDAC6", "Xp11.23", "ENSG00000094631", "AF132609", "Histone deacetylases, class IIB,Protein phosphatase 1 regulatory subunits", true, "[true,false,false]", 14064, "gene with protein product", "NM_006044", "[\"protein phosphatase 1\",\"regulatory subunit 90\"]", "Q9UBN7" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4777822714750551052L, "adenosine deaminase", "ADA", "20q13.12", "ENSG00000196839", "X02994", "Adenosine deaminase family", true, "[true,false,false]", 186, "gene with protein product", "NM_000022", "[]", "P00813" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2835683698691572728L, "fragile histidine triad", "FHIT", "3p14.2", "ENSG00000189283", "BC032336", "", true, "[true,false,false]", 3701, "gene with protein product", "NM_002012", "[]", "P49789" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6229417169330484651L, "galactosidase alpha", "GLA", "Xq22.1", "ENSG00000102393", "X16889", "Galactosidases alpha", true, "[true,false,false]", 4296, "gene with protein product", "NM_000169", "[]", "P06280" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -955855002833216383L, "HRas proto-oncogene, GTPase", "HRAS", "11p15.5", "ENSG00000174775", "AJ437024", "RAS type GTPase family", true, "[true,false,false]", 5173, "gene with protein product", "NM_176795", "[]", "P01112" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -846720960733617492L, "egl-9 family hypoxia inducible factor 1", "EGLN1", "1q42.2", "ENSG00000135766", "AJ310543", "Zinc fingers MYND-type", true, "[true,false,false]", 1232, "gene with protein product", "NM_022051", "[\"HIF prolyl hydroxylase 2\"]", "Q9GZT9" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2078916802834698371L, "butyrylcholinesterase", "BCHE", "3q26.1", "ENSG00000114200", "M16541", "", true, "[true,false,false]", 983, "gene with protein product", "NM_000055", "[]", "P06276" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5989283040142880941L, "G protein subunit alpha i1", "GNAI1", "7q21.11", "ENSG00000127955", "AL049933", "G protein subunits alpha, group i", true, "[true,false,false]", 4384, "gene with protein product", "NM_002069", "[\"Gi1 protein alpha subunit\",\"Guanine nucleotide-binding protein G(i) subunit alpha-1\"]", "P63096" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8937012576425917013L, "proliferating cell nuclear antigen", "PCNA", "20p12.3", "ENSG00000132646", "J04718", "", true, "[true,false,false]", 8729, "gene with protein product", "NM_002592", "[]", "P12004" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3766953543599224750L, "tubulin beta class I", "TUBB", "6p21.33", "ENSG00000196230", "AB062393", "Tubulins", true, "[true,false,false]", 20778, "gene with protein product", "NM_178014", "[\"class I beta-tubulin\",\"beta1-tubulin\"]", "P07437" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2712453573791206566L, "KRAS proto-oncogene, GTPase", "KRAS", "12p12.1", "ENSG00000133703", "BC010502", "RAS type GTPase family", true, "[true,false,false]", 6407, "gene with protein product", "NM_033360", "[]", "P01116" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8441602990058020191L, "MDM2 proto-oncogene", "MDM2", "12q15", "ENSG00000135679", "", "Zinc fingers RANBP2-type ,Ring finger proteins", true, "[true,false,false]", 6973, "gene with protein product", "NM_006880", "[]", "Q00987" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4461831045071011463L, "3-phosphoinositide dependent protein kinase 1", "PDPK1", "16p13.3", "ENSG00000140992", "AF017995", "AGC family kinases", true, "[true,false,false]", 8816, "gene with protein product", "NM_001261816", "[\"PkB kinase\"]", "O15530" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3985314229698254447L, "cholinergic receptor nicotinic alpha 2 subunit", "CHRNA2", "8p21.2", "ENSG00000120903", "U62431", "Cholinergic receptors nicotinic subunits", true, "[true,false,false]", 1956, "gene with protein product", "NM_000742", "[\"acetylcholine receptor\",\"nicotinic\",\"alpha 2 (neuronal)\"]", "Q15822" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1211540942351445484L, "cyclin dependent kinase 2", "CDK2", "12q13.2", "ENSG00000123374", "M68520", "Cyclin dependent kinases", true, "[true,false,false]", 1771, "gene with protein product", "NM_001290230", "[]", "P24941" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4549900727149064389L, "RAR related orphan receptor C", "RORC", "1q21", "ENSG00000143365", "U16997", "Nuclear hormone receptors", true, "[true,false,false]", 10260, "gene with protein product", "NM_001001523", "[]", "P51449" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2164923636600567989L, "androgen receptor", "AR", "Xq12", "ENSG00000169083", "M20132", "Nuclear hormone receptors", true, "[true,false,false]", 644, "gene with protein product", "NM_000044", "[\"testicular feminization\",\"Kennedy disease\"]", "P10275" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -845697480161923433L, "alpha-N-acetylgalactosaminidase", "NAGA", "22q13.2", "ENSG00000198951", "", "Galactosidases alpha", true, "[true,false,false]", 7631, "gene with protein product", "NM_000262", "[\"alpha-galactosidase B\"]", "P17050" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7942879173081689985L, "mitogen-activated protein kinase kinase 6", "MAP2K6", "17q24.3", "ENSG00000108984", "U39064", "Mitogen-activated protein kinase kinases", true, "[true,false,false]", 6846, "gene with protein product", "NM_002758", "[\"protein kinase\",\"mitogen-activated\",\"kinase 6 (MAP kinase kinase 6)\"]", "P52564" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -137485887315253818L, "endothelin converting enzyme 1", "ECE1", "1p36.12", "ENSG00000117298", "D49471", "M13 metallopeptidases", true, "[true,false,false]", 3146, "gene with protein product", "NM_001397", "[]", "P42892" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1715148413798868644L, "matrix metallopeptidase 3", "MMP3", "11q22.2", "ENSG00000149968", "X05232", "M10 matrix metallopeptidases", true, "[true,false,false]", 7173, "gene with protein product", "NM_002422", "[]", "P08254" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5391536805684456842L, "fibroblast growth factor receptor 2", "FGFR2", "10q26.13", "ENSG00000066468", "AK026508", "I-set domain containing,CD molecules,Receptor tyrosine kinases", true, "[true,false,false]", 3689, "gene with protein product", "NM_022976", "[\"Crouzon syndrome\",\"Pfeiffer syndrome\"]", "P21802" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6297746589230566373L, "peroxisome proliferator activated receptor alpha", "PPARA", "22q13.31", "ENSG00000186951", "L02932", "Nuclear hormone receptors", true, "[true,false,false]", 9232, "gene with protein product", "NM_001001928", "[]", "Q07869" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5515557467982057572L, "fibroblast growth factor receptor 1", "FGFR1", "8p11.23", "ENSG00000077782", "M34185", "I-set domain containing,CD molecules,Receptor tyrosine kinases", true, "[true,false,false]", 3688, "gene with protein product", "NM_001174063", "[\"Pfeiffer syndrome\"]", "P11362" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8324320231433162360L, "peroxisome proliferator activated receptor gamma", "PPARG", "3p25.2", "ENSG00000132170", "X90563", "Nuclear hormone receptors", true, "[true,false,false]", 9236, "gene with protein product", "NM_005037", "[]", "P37231" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2666711242041094845L, "peroxisome proliferator activated receptor delta", "PPARD", "6p21.31", "ENSG00000112033", "L07592", "Nuclear hormone receptors", true, "[true,false,false]", 9235, "gene with protein product", "NM_006238", "[]", "Q03181" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1166900776849744201L, "LCK proto-oncogene, Src family tyrosine kinase", "LCK", "1p35.2", "ENSG00000182866", "M36881", "SH2 domain containing,Src family tyrosine kinases", true, "[true,false,false]", 6524, "gene with protein product", "NM_005356", "[]", "P06239" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2099448898017149142L, "histamine N-methyltransferase", "HNMT", "2q22.1", "ENSG00000150540", "", "Seven-beta-strand methyltransferase motif containing", true, "[true,false,false]", 5028, "gene with protein product", "NM_001024074", "[]", "P50135" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4220625135268562561L, "activin A receptor like type 1", "ACVRL1", "12q13.13", "ENSG00000139567", "L17075", "Type 1 receptor serine/threonine kinases", true, "[true,false,false]", 175, "gene with protein product", "NM_000020", "[\"activin receptor-like kinase 1\"]", "P37023" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4790809478792554689L, "AKT serine/threonine kinase 1", "AKT1", "14q32.33", "ENSG00000142208", "M63167", "Pleckstrin homology domain containing,AGC family kinases", true, "[true,false,false]", 391, "gene with protein product", "NM_005163", "[\"protein kinase B\"]", "P31749" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5749989344462949150L, "tubulin alpha 1b", "TUBA1B", "12q13.12", "ENSG00000123416", "AF081484", "Tubulins", true, "[true,false,false]", 18809, "gene with protein product", "NM_006082", "[\"tubulin\",\"alpha\",\"ubiquitous\"]", "P68363" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8503359759198411895L, "arginase 1", "ARG1", "6q23.2", "ENSG00000118520", "", "", true, "[true,false,false]", 663, "gene with protein product", "NM_000045", "[]", "P05089" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2523904323150379372L, "estrogen receptor 1", "ESR1", "6q25.1-q25.2", "ENSG00000091831", "X03635", "Nuclear hormone receptors", true, "[true,false,false]", 3467, "gene with protein product", "NM_000125", "[\"nuclear receptor subfamily 3 group A member 1\",\"estrogen receptor alpha\",\"oestrogen receptor alpha\",\"E2 receptor alpha\"]", "P03372" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3718266994377307792L, "phospholipase A2 group IIA", "PLA2G2A", "1p36.13", "ENSG00000188257", "BC005919", "Phospholipases", true, "[true,false,false]", 9031, "gene with protein product", "NM_000300", "[]", "P14555" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1978117211287056744L, "lactate dehydrogenase B", "LDHB", "12p12.1", "ENSG00000111716", "", "", true, "[true,false,false]", 6541, "gene with protein product", "NM_002300", "[]", "P07195" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8314325034680199370L, "colony stimulating factor 1 receptor", "CSF1R", "5q32", "ENSG00000182578", "U63963", "Immunoglobulin like domain containing,CD molecules,Receptor tyrosine kinases", true, "[true,false,false]", 2433, "gene with protein product", "NM_005211", "[]", "P07333" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4536125327231651983L, "cytochrome P450 family 17 subfamily A member 1", "CYP17A1", "10q24.32", "ENSG00000148795", "M19489", "Cytochrome P450 family 17", true, "[true,false,false]", 2593, "gene with protein product", "NM_000102", "[\"Steroid 17-alpha-monooxygenase\"]", "P05093" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5524720654063828505L, "cathepsin L", "CTSL", "9q21.33", "ENSG00000135047", "X12451", "Cathepsins", true, "[true,false,false]", 2537, "gene with protein product", "NM_001912", "[]", "P07711" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8232453929604150898L, "cholinergic receptor nicotinic beta 2 subunit", "CHRNB2", "1q21.3", "ENSG00000160716", "U62437", "Cholinergic receptors nicotinic subunits", true, "[true,false,false]", 1962, "gene with protein product", "NM_000748", "[\"acetylcholine receptor\",\"nicotinic\",\"beta 2 (neuronal)\"]", "P17787" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5192006528371093992L, "receptor interacting serine/threonine kinase 2", "RIPK2", "8q21.3", "ENSG00000104312", "AC004003", "Caspase recruitment domain containing", true, "[true,false,false]", 10020, "gene with protein product", "NM_003821", "[]", "O43353" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -780486182335129183L, "glutathione S-transferase mu 1", "GSTM1", "1p13.3", "ENSG00000134184", "BC036805", "Soluble glutathione S-transferases", true, "[true,false,false]", 4632, "gene with protein product", "NM_000561", "[]", "P09488" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8428139013121393655L, "phospholipase A2 group VII", "PLA2G7", "6p12.3", "ENSG00000146070", "U20157", "Phospholipases", true, "[true,false,false]", 9040, "gene with protein product", "NM_001168357", "[]", "Q13093" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5460190876110622827L, "renin", "REN", "1q32.1", "ENSG00000143839", "BC047752", "", true, "[true,false,false]", 9958, "gene with protein product", "NM_000537", "[]", "P00797" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3222058892820879647L, "angiotensin I converting enzyme 2", "ACE2", "Xp22.2", "ENSG00000130234", "AF291820", "", true, "[true,false,false]", 13557, "gene with protein product", "NM_021804", "[\"peptidyl-dipeptidase A\"]", "Q9BYF1" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2154481941514157632L, "trace amine associated receptor 1", "TAAR1", "6q23.2", "ENSG00000146399", "AY180374", "Trace amine receptors", true, "[true,true,true]", 17734, "gene with protein product", "NM_138327", "[\"TA1\",\"TAR1\"]", "Q96RJ0" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8997054009694923741L, "thyroid stimulating hormone receptor", "TSHR", "14q24-q31", "ENSG00000165409", "AY429111", "Glycoprotein hormone receptors", true, "[true,true,true]", 12373, "gene with protein product", "NM_000369", "[\"LGR3\"]", "P16473" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3744922911417106480L, "platelet activating factor receptor", "PTAFR", "1p35.3", "ENSG00000169403", "BC063000", "Platelet activating factor receptor", true, "[true,true,true]", 9582, "gene with protein product", "NM_000952", "[]", "P25105" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6085629256296895668L, "opioid receptor mu 1", "OPRM1", "6q25.2", "ENSG00000112038", "L29301", "Opioid receptors", true, "[true,true,true]", 8156, "gene with protein product", "NM_000914", "[\"MOR1\"]", "P35372" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8672482639517129554L, "opioid receptor kappa 1", "OPRK1", "8q11.23", "ENSG00000082556", "", "Opioid receptors", true, "[true,true,true]", 8154, "gene with protein product", "NM_000912", "[\"KOR\",\"OPRK\"]", "P41145" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8206411860240424270L, "opioid receptor delta 1", "OPRD1", "1p35.3", "ENSG00000116329", "U10504", "Opioid receptors", true, "[true,true,true]", 8153, "gene with protein product", "NM_000911", "[]", "P41143" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3943084629894404857L, "neuropeptide Y receptor Y5", "NPY5R", "4q32.2", "ENSG00000164129", "BC042416", "Neuropeptide receptors", true, "[true,true,true]", 7958, "gene with protein product", "NM_006174", "[\"NPYR5\"]", "Q15761" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1569061970222943319L, "neuropeptide Y receptor Y4", "NPY4R", "10q11.22", "ENSG00000204174", "", "Neuropeptide receptors", true, "[true,true,true]", 9329, "gene with protein product", "NM_005972", "[\"PP1\",\"Y4\"]", "P50391" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6191195604262581560L, "neuropeptide Y receptor Y2", "NPY2R", "4q32.1", "ENSG00000185149", "U42766", "Neuropeptide receptors", true, "[true,true,true]", 7957, "gene with protein product", "NM_000910", "[]", "P49146" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4556375078662851464L, "neuropeptide Y receptor Y1", "NPY1R", "4q32.2", "ENSG00000164128", "", "Neuropeptide receptors", true, "[true,false,true]", 7956, "gene with protein product", "NM_000909", "[]", "P25929" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8629079639376559678L, "neuropeptide S receptor 1", "NPSR1", "7p14.3", "ENSG00000187258", "AY255536", "Neuropeptide receptors", true, "[true,true,true]", 23631, "gene with protein product", "NM_207173", "[\"GPRA\",\"PGR14\"]", "Q6W5P4" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4199027515256101549L, "neuropeptide FF receptor 1", "NPFFR1", "10q22.1", "ENSG00000148734", "AB040104", "Neuropeptide receptors", true, "[true,true,true]", 17425, "gene with protein product", "NM_022146", "[\"\\\"neuropeptide FF 1\\\"\",\"NPFF1R1\",\"OT7T022\"]", "Q9GZQ6" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2180131563124354864L, "neuropeptides B and W receptor 1", "NPBWR1", "8q11.23", "ENSG00000183729", "BC033145", "Neuropeptide receptors", true, "[true,true,true]", 4522, "gene with protein product", "NM_005285", "[]", "P48145" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1285800990388487622L, "opioid related nociceptin receptor 1", "OPRL1", "20q13.33", "ENSG00000125510", "", "Opioid receptors", true, "[true,true,true]", 8155, "gene with protein product", "NM_182647", "[\"\\\"kappa3-related opioid receptor\\\"\",\"KOR-3\",\"\\\"LC132 receptor-like\\\"\",\"\\\"nociceptin/orphanin FQ receptor\\\"\",\"NOCIR\",\"NOPr\",\"OOR\",\"ORL1\",\"\\\"orphanin FQ receptor\\\"\"]", "P41146" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8107184554923835698L, "tachykinin receptor 2", "TACR2", "10q22.1", "ENSG00000075073", "", "Tachykinin receptors", true, "[true,true,true]", 11527, "gene with protein product", "NM_001057", "[\"NK2R\",\"SKR\"]", "P21452" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8255296235676472749L, "tachykinin receptor 1", "TACR1", "2p12", "ENSG00000115353", "M76675", "Tachykinin receptors", true, "[true,true,true]", 11526, "gene with protein product", "NM_001058", "[\"NK1R\",\"NKIR\",\"SPR\"]", "P25103" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6712022154609725180L, "glutamate metabotropic receptor 8", "GRM8", "7q31.33", "ENSG00000179603", "", "Glutamate metabotropic receptors", true, "[true,true,true]", 4600, "gene with protein product", "NM_000845", "[\"GLUR8\",\"GPRC1H\",\"mGlu8\",\"MGLUR8\"]", "O00222" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8757030924402031580L, "glutamate metabotropic receptor 7", "GRM7", "3p26.1", "ENSG00000196277", "U92458", "Glutamate metabotropic receptors", true, "[true,true,true]", 4599, "gene with protein product", "NM_000844", "[\"GLUR7\",\"GPRC1G\",\"mGlu7\",\"MGLUR7\",\"PPP1R87\",\"\\\"protein phosphatase 1\",\"regulatory subunit 87\\\"\"]", "Q14831" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7824885225118565229L, "glutamate metabotropic receptor 6", "GRM6", "5q35.3", "ENSG00000113262", "U82083", "Glutamate metabotropic receptors", true, "[true,true,true]", 4598, "gene with protein product", "NM_000843", "[\"CSNB1B\",\"GPRC1F\",\"mGlu6\",\"MGLUR6\"]", "O15303" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6730625874099210208L, "glutamate metabotropic receptor 5", "GRM5", "11q14.2-q14.3", "ENSG00000168959", "D28538", "Glutamate metabotropic receptors", true, "[true,true,true]", 4597, "gene with protein product", "NM_000842", "[\"GPRC1E\",\"mGlu5\",\"MGLUR5\",\"PPP1R86\",\"\\\"protein phosphatase 1\",\"regulatory subunit 86\\\"\"]", "P41594" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5739238604861719704L, "glutamate metabotropic receptor 4", "GRM4", "6p21.31", "ENSG00000124493", "U92457", "Glutamate metabotropic receptors", true, "[true,true,true]", 4596, "gene with protein product", "NM_000841", "[\"GPRC1D\",\"mGlu4\",\"MGLUR4\"]", "Q14833" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6827465469318017189L, "glutamate metabotropic receptor 3", "GRM3", "7q21.11-q21.12", "ENSG00000198822", "", "Glutamate metabotropic receptors", true, "[true,true,true]", 4595, "gene with protein product", "NM_000840", "[\"GPRC1C\",\"mGlu3\",\"MGLUR3\"]", "Q14832" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5919513186250160125L, "glutamate metabotropic receptor 2", "GRM2", "3p21.2", "ENSG00000164082", "L35318", "Glutamate metabotropic receptors", true, "[true,true,true]", 4594, "gene with protein product", "NM_000839", "[\"GPRC1B\",\"mGlu2\",\"MGLUR2\"]", "Q14416" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4949204605683976708L, "glutamate metabotropic receptor 1", "GRM1", "6q24.3", "ENSG00000152822", "U31215", "Glutamate metabotropic receptors", true, "[true,true,true]", 4593, "gene with protein product", "NM_000838", "[\"GPRC1A\",\"mGlu1\",\"MGLUR1\",\"PPP1R85\",\"\\\"protein phosphatase 1\",\"regulatory subunit 85\\\"\"]", "Q13255" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3660840146811804490L, "melanocortin 5 receptor", "MC5R", "18p11.21", "ENSG00000176136", "AY268429", "Melanocortin receptors", true, "[true,true,true]", 6933, "gene with protein product", "NM_005913", "[]", "P33032" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2268982485882712052L, "vasoactive intestinal peptide receptor 1", "VIPR1", "3p22.1", "ENSG00000114812", "AH005329", "Vasoactive intestinal peptide receptor family", true, "[true,true,true]", 12694, "gene with protein product", "NM_004624", "[\"HVR1\",\"RDC1\",\"\\\"VIP and PACAP receptor 1\\\"\",\"VPAC1\",\"VPAC1R\"]", "P32241" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1627767953745793413L, "melanocortin 4 receptor", "MC4R", "18q21.32", "ENSG00000166603", "AY236539", "Melanocortin receptors", true, "[true,true,true]", 6932, "gene with protein product", "NM_005912", "[]", "P32245" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8206449840496857318L, "arginine vasopressin receptor 1A", "AVPR1A", "12q14.2", "ENSG00000166148", "L25615", "Arginine vasopressin and oxytocin receptors", true, "[true,true,true]", 895, "gene with protein product", "NM_000706", "[]", "P37288" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7500897822625621878L, "apoptotic peptidase activating factor 1", "APAF1", "12q23.1", "ENSG00000120868", "AF013263", "Apoptosome,WD repeat domain containing,Caspase recruitment domain containing", true, "[true,false,false]", 576, "gene with protein product", "NM_181861.1", "[]", "O14727" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8336912603629409240L, "arginase 2", "ARG2", "14q24.1", "ENSG00000081181", "D86724", "", true, "[true,false,false]", 664, "gene with protein product", "NM_001172", "[]", "P78540" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -149420345163456575L, "orosomucoid 1", "ORM1", "9q32", "ENSG00000229314", "", "Lipocalins", true, "[true,false,false]", 8498, "gene with protein product", "NM_000607", "[]", "P02763" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8037247376208615722L, "mitogen-activated protein kinase 3", "MAPK3", "16p11.2", "ENSG00000102882", "M84490", "Mitogen-activated protein kinases", true, "[true,false,false]", 6877, "gene with protein product", "NM_001040056", "[]", "P27361" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1450154453344748524L, "mitogen-activated protein kinase 1", "MAPK1", "22q11.22", "ENSG00000100030", "M84489", "Mitogen-activated protein kinases", true, "[true,false,false]", 6871, "gene with protein product", "NM_002745", "[]", "P28482" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8163353798158562701L, "phosphodiesterase 5A", "PDE5A", "4q26", "ENSG00000138735", "D89094", "Phosphodiesterases", true, "[true,false,false]", 8784, "gene with protein product", "NM_001083", "[]", "O76074" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4858499365994228372L, "prostaglandin I2 synthase", "PTGIS", "20q13.13", "ENSG00000124212", "", "Cytochrome P450 family 8", true, "[true,false,false]", 9603, "gene with protein product", "NM_000961", "[\"cytochrome P450\",\"family 8\",\"subfamily A\",\"polypeptide 1\",\"prostacyclin synthase\"]", "Q16647" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4985388526247212215L, "prostaglandin-endoperoxide synthase 2", "PTGS2", "1q31.1", "ENSG00000073756", "D28235", "", true, "[true,false,false]", 9605, "gene with protein product", "NM_000963", "[\"prostaglandin G/H synthase 2\",\"cyclooxygenase 2\"]", "P35354" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5427690752003907742L, "retinoic acid receptor beta", "RARB", "3p24.2", "ENSG00000077092", "Y00291", "Nuclear hormone receptors", true, "[true,false,false]", 9865, "gene with protein product", "NM_000965", "[]", "P10826" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8345770078729361410L, "FYN proto-oncogene, Src family tyrosine kinase", "FYN", "6q21", "ENSG00000010810", "AK056699", "SH2 domain containing,Src family tyrosine kinases", true, "[true,false,false]", 4037, "gene with protein product", "NM_002037", "[]", "P06241" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5886512473682800861L, "lysine methyltransferase 2D", "KMT2D", "12q13.12", "ENSG00000167548", "AF010403", "PHD finger proteins,SET domain containing,Lysine methyltransferases,Trinucleotide repeat containing", true, "[true,false,false]", 7133, "gene with protein product", "NM_003482", "[\"histone-lysine N-methyltransferase 2D\"]", "O14686" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -291280646142093809L, "kinesin family member 5B", "KIF5B", "10p11.22", "ENSG00000170759", "X65873", "Kinesins", true, "[true,false,false]", 6324, "gene with protein product", "NM_004521", "[]", "P33176" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -9093983742726377489L, "dimethylarginine dimethylaminohydrolase 1", "DDAH1", "1p22.3", "ENSG00000153904", "AB001915", "", true, "[true,false,false]", 2715, "gene with protein product", "NM_001134445", "[]", "O94760" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2249604879658191454L, "carboxypeptidase N subunit 1", "CPN1", "10q24.2", "ENSG00000120054", "X14329", "M14 carboxypeptidases", true, "[true,false,false]", 2312, "gene with protein product", "NM_001308", "[\"anaphylatoxin inactivator\",\"arginine carboxypeptidase\",\"carboxypeptidase K\",\"kininase I\",\"lysine carboxypeptidase\"]", "P15169" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5313464769029762524L, "tyrosine kinase 2", "TYK2", "19p13.2", "ENSG00000105397", "", "Jak family tyrosine kinases,FERM domain containing", true, "[true,false,false]", 12440, "gene with protein product", "NM_003331", "[]", "P29597" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2023810178841768308L, "angiotensin II receptor type 1", "AGTR1", "3q24", "ENSG00000144891", "M87290", "Angiotensin receptors", true, "[true,false,false]", 336, "gene with protein product", "NM_000685", "[]", "P30556" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4883595599005139689L, "CD38 molecule", "CD38", "4p15.32", "ENSG00000004468", "D84276", "CD molecules", true, "[true,false,false]", 1667, "gene with protein product", "NM_001775", "[\"ADP-ribosyl cyclase 1\",\"NAD(+) nucleosidase\"]", "P28907" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5302977922417386818L, "phenylethanolamine N-methyltransferase", "PNMT", "17q12", "ENSG00000141744", "", "Seven-beta-strand methyltransferase motif containing", true, "[true,false,false]", 9160, "gene with protein product", "NM_002686", "[]", "P11086" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8687095776931538495L, "MCL1, BCL2 family apoptosis regulator", "MCL1", "1q21.2", "ENSG00000143384", "BC017197", "BCL2 family", true, "[true,false,false]", 6943, "gene with protein product", "NM_021960", "[]", "Q07820" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4581394756164577178L, "kallikrein B1", "KLKB1", "4q35.2", "ENSG00000164344", "M13143", "Kallikreins", true, "[true,false,false]", 6371, "gene with protein product", "NM_000892", "[\"Fletcher factor\"]", "P03952" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4162712006930991577L, "ABL proto-oncogene 1, non-receptor tyrosine kinase", "ABL1", "9q34.12", "ENSG00000097007", "M14752", "SH2 domain containing,Abl family tyrosine kinases", true, "[true,false,false]", 76, "gene with protein product", "NM_007313", "[]", "P00519" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -661819104833095392L, "carbonic anhydrase 12", "CA12", "15q22.2", "ENSG00000074410", "AF051882", "Carbonic anhydrases", true, "[true,false,false]", 1371, "gene with protein product", "NM_001218", "[]", "O43570" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8450050534580037068L, "tubulin beta 3 class III", "TUBB3", "16q24.3", "ENSG00000258947", "BC000748", "Tubulins", true, "[true,false,false]", 20772, "gene with protein product", "NM_006086", "[\"class III beta-tubulin\"]", "Q13509" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2061277852396023855L, "tubulin alpha 1a", "TUBA1A", "12q13.12", "ENSG00000167552", "AF141347", "Tubulins", true, "[true,false,false]", 20766, "gene with protein product", "NM_006009", "[\"tubulin\",\"alpha\",\"brain-specific\"]", "Q71U36" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5347145832373205506L, "death associated protein kinase 1", "DAPK1", "9q21.33", "ENSG00000196730", "X76104", "Death associated protein kinases,Ankyrin repeat domain containing,Roco domain containing", true, "[true,false,false]", 2674, "gene with protein product", "NM_004938", "[]", "P53355" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -469991249225005575L, "creatine kinase B", "CKB", "14q32.33", "ENSG00000166165", "", "", true, "[true,false,false]", 1991, "gene with protein product", "NM_001823", "[\"creatine kinase brain-type\"]", "P12277" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4042163546734634376L, "glyoxalase I", "GLO1", "6p21.2", "ENSG00000124767", "L07837", "", true, "[true,false,false]", 4323, "gene with protein product", "NM_006708", "[\"glyoxalase domain containing 1\"]", "Q04760" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5151491594611410685L, "melanocortin 3 receptor", "MC3R", "20q13.2", "ENSG00000124089", "", "Melanocortin receptors", true, "[true,true,true]", 6931, "gene with protein product", "NM_019888", "[\"MC3\"]", "P41968" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2444774081880887098L, "melanocortin 2 receptor", "MC2R", "18p11.2", "ENSG00000185231", "", "Melanocortin receptors", false, "[true,true,true]", 6930, "gene with protein product", "NM_000529", "[\"ACTHR\",\"\\\"adrenocorticotropic hormone receptor\\\"\"]", "Q01718" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7089017631554039642L, "melanocortin 1 receptor", "MC1R", "16q24.3", "ENSG00000258839", "", "Melanocortin receptors", true, "[true,true,true]", 6929, "gene with protein product", "NM_002386", "[\"\\\"alpha melanocyte stimulating hormone receptor\\\"\",\"MSH-R\"]", "Q01726" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3280257464032361096L, "bradykinin receptor B2", "BDKRB2", "14q32.2", "ENSG00000168398", "S56772", "Bradykinin receptors", true, "[true,true,true]", 1030, "gene with protein product", "NM_000623", "[\"BK-2\"]", "P30411" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6885115091375445152L, "adrenoceptor beta 3", "ADRB3", "8p11.23", "ENSG00000188778", "AY487247", "Adrenoceptors", true, "[true,true,true]", 288, "gene with protein product", "NM_000025", "[]", "P13945" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1171941529448516172L, "adrenoceptor beta 2", "ADRB2", "5q32", "ENSG00000169252", "AF022953", "Adrenoceptors", true, "[true,true,true]", 286, "gene with protein product", "NM_000024", "[\"ADRBR\",\"B2AR\",\"BAR\"]", "P07550" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6144193946560537317L, "adrenoceptor beta 1", "ADRB1", "10q25.3", "ENSG00000043591", "J03019", "Adrenoceptors", true, "[true,true,true]", 285, "gene with protein product", "NM_000684", "[]", "P08588" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8194767268025886069L, "angiotensin II receptor type 2", "AGTR2", "Xq23", "ENSG00000180772", "AY324607", "Angiotensin receptors", true, "[true,true,true]", 338, "gene with protein product", "NM_000686", "[\"AT2\",\"MRX88\"]", "P50052" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8657283579784734272L, "adrenoceptor alpha 2C", "ADRA2C", "4p16.3", "ENSG00000184160", "AY455666", "Adrenoceptors", true, "[true,true,true]", 283, "gene with protein product", "NM_000683", "[\"ADRARL2\"]", "P18825" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6366722946110467482L, "adrenoceptor alpha 2B", "ADRA2B", "2q11.2", "ENSG00000274286", "M34041", "Adrenoceptors", true, "[true,true,true]", 282, "gene with protein product", "NM_000682", "[\"ADRARL1\"]", "P18089" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1372670201000926075L, "adrenoceptor alpha 2A", "ADRA2A", "10q25.2", "ENSG00000150594", "AF284095", "Adrenoceptors", true, "[true,true,true]", 281, "gene with protein product", "NM_000681", "[\"\\\" alpha-2A-adrenergic receptor\\\"\",\"ADRAR\",\"\\\"alpha-2AAR subtype C10\\\"\"]", "P08913" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5535486562525788268L, "adrenoceptor alpha 1D", "ADRA1D", "20p13", "ENSG00000171873", "U03864", "Adrenoceptors", true, "[true,true,true]", 280, "gene with protein product", "NM_000678", "[\"ADRA1\",\"ADRA1A\",\"ADRA1R\"]", "P25100" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8557899630359207531L, "adenosine A3 receptor", "ADORA3", "1p13.2", "ENSG00000282608", "BC029831", "Adenosine receptors", true, "[true,true,true]", 268, "gene with protein product", "NM_000677+OR+NM_020683", "[\"AD026\"]", "P0DMS8" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2755481282972892811L, "adenosine A2b receptor", "ADORA2B", "17p12", "ENSG00000170425", "M97759", "Adenosine receptors", true, "[true,true,true]", 264, "gene with protein product", "NM_000676", "[]", "P29275" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5863638504500477864L, "adenosine A2a receptor", "ADORA2A", "22q11.23", "ENSG00000128271", "X68486", "Adenosine receptors", true, "[true,true,true]", 263, "gene with protein product", "NM_000675", "[\"RDC8\"]", "P29274" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3166423890621111369L, "adenosine A1 receptor", "ADORA1", "1q32.1", "ENSG00000163485", "BC026340", "Adenosine receptors", true, "[true,true,true]", 262, "gene with protein product", "NM_000674", "[\"RDC7\"]", "P30542" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1008786115010631327L, "5-hydroxytryptamine receptor 7", "HTR7", "10q23.31", "ENSG00000148680", "BC047526", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5302, "gene with protein product", "NM_000872", "[\"5-HT7\"]", "P34969" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8431991881175285893L, "5-hydroxytryptamine receptor 6", "HTR6", "1p36.13", "ENSG00000158748", "L41147", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5301, "gene with protein product", "NM_000871", "[\"5-HT6\",\"5-HT6R\"]", "P50406" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8216965585793044005L, "5-hydroxytryptamine receptor 5A", "HTR5A", "7q36.2", "ENSG00000157219", "", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5300, "gene with protein product", "NM_024012", "[\"5-HT5A\"]", "P47898" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4367194148999708396L, "5-hydroxytryptamine receptor 4", "HTR4", "5q32", "ENSG00000164270", "Y08756", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5299, "gene with protein product", "NM_000870", "[\"5-HT4\"]", "Q13639" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5918464503077828884L, "5-hydroxytryptamine receptor 2C", "HTR2C", "Xq23", "ENSG00000147246", "", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5295, "gene with protein product", "NM_000868", "[\"5-HT2C\",\"5HTR2C\"]", "P28335" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6305132363760067150L, "5-hydroxytryptamine receptor 2B", "HTR2B", "2q37.1", "ENSG00000135914", "", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5294, "gene with protein product", "NM_000867", "[\"5-HT(2B)\",\"5-HT2B\"]", "P41595" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4271606637158677116L, "5-hydroxytryptamine receptor 2A", "HTR2A", "13q14.2", "ENSG00000102468", "X57830", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5293, "gene with protein product", "NM_000621", "[\"5-HT2A\"]", "P28223" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8618772611880551132L, "5-hydroxytryptamine receptor 1F", "HTR1F", "3p12", "ENSG00000179097", "L05597", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5292, "gene with protein product", "NM_000866", "[\"5-HT1F\",\"HTR1EL\"]", "P30939" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2960586528245383528L, "5-hydroxytryptamine receptor 1E", "HTR1E", "6q14.3", "ENSG00000168830", "", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5291, "gene with protein product", "NM_000865", "[\"5-HT1E\"]", "P28566" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 9150556276723070326L, "5-hydroxytryptamine receptor 1D", "HTR1D", "1p36.12", "ENSG00000179546", "M89955", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5289, "gene with protein product", "NM_000864", "[\"5-HT1D\",\"HT1DA\",\"RDC4\"]", "P28221" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2891508762551249936L, "5-hydroxytryptamine receptor 1B", "HTR1B", "6q14.1", "ENSG00000135312", "BC069065", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5287, "gene with protein product", "NM_000863", "[\"5-HT1B\",\"5-HT1DB\",\"HTR1D2\",\"S12\"]", "P28222" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1011270477136425037L, "5-hydroxytryptamine receptor 1A", "HTR1A", "5q12.3", "ENSG00000178394", "AF498978", "5-hydroxytryptamine receptors, G protein-coupled", true, "[true,true,true]", 5286, "gene with protein product", "NM_000524", "[\"5-HT1A\"]", "P08908" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2456961155520488105L, "calcitonin receptor", "CALCR", "7q21.3", "ENSG00000004948", "L00587", "Calcitonin receptors", true, "[true,true,true]", 1440, "gene with protein product", "NM_001742", "[\"CTR\"]", "P30988" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8397812296855956774L, "cannabinoid receptor 1", "CNR1", "6q15", "ENSG00000118432", "AF107262", "Cannabinoid receptors", true, "[true,true,true]", 2159, "gene with protein product", "NM_001160226", "[\"CANN6\",\"CB-R\",\"CB1\",\"CB1A\",\"CB1K5\"]", "P21554" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -180786589000152212L, "cannabinoid receptor 2", "CNR2", "1p36.11", "ENSG00000188822", "X74328", "Cannabinoid receptors", true, "[true,true,true]", 2160, "gene with protein product", "NM_001841", "[\"CB2\"]", "P34972" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3195634977243934443L, "cholecystokinin A receptor", "CCKAR", "4p15.2", "ENSG00000163394", "L19315", "Cholecystokinin receptors", true, "[true,true,true]", 1570, "gene with protein product", "NM_000730", "[]", "P32238" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2483229631620007187L, "cholinergic receptor muscarinic 5", "CHRM5", "15q14", "ENSG00000184984", "", "Cholinergic receptors muscarinic", true, "[true,true,true]", 1954, "gene with protein product", "NM_001320917", "[\"\\\"acetylcholine receptor\",\"muscarinic 5\\\"\"]", "P08912" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5812648385083634542L, "cholinergic receptor muscarinic 4", "CHRM4", "11p11.2", "ENSG00000180720", "M16405", "Cholinergic receptors muscarinic", true, "[true,true,true]", 1953, "gene with protein product", "NM_000741", "[\"\\\"acetylcholine receptor\",\"muscarinic 4\\\"\"]", "P08173" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2959201505920494760L, "cholinergic receptor muscarinic 3", "CHRM3", "1q43", "ENSG00000133019", "U29589", "Cholinergic receptors muscarinic", true, "[true,true,true]", 1952, "gene with protein product", "NM_000740", "[\"\\\"acetylcholine receptor\",\"muscarinic 3\\\"\"]", "P20309" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4974100470931936590L, "cholinergic receptor muscarinic 2", "CHRM2", "7q33", "ENSG00000181072", "", "Cholinergic receptors muscarinic", true, "[true,true,true]", 1951, "gene with protein product", "NM_000739", "[\"\\\"acetylcholine receptor\",\"muscarinic 2\\\"\"]", "P08172" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4265818074949461259L, "cholinergic receptor muscarinic 1", "CHRM1", "11q12.3", "ENSG00000168539", "Y00508", "Cholinergic receptors muscarinic", true, "[true,true,true]", 1950, "gene with protein product", "NM_000738", "[\"\\\"acetylcholine receptor\",\"muscarinic 1\\\"\"]", "P11229" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -718657767516142007L, "histamine receptor H4", "HRH4", "18q11.2", "ENSG00000134489", "AF312230", "Histamine receptors", true, "[true,true,true]", 17383, "gene with protein product", "NM_001143828", "[\"AXOR35\",\"GPCR105\",\"GPRv53\",\"H4R\",\"HH4R\"]", "Q9H3N8" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -258865047799651018L, "histamine receptor H3", "HRH3", "20q13.33", "ENSG00000101180", "AF140538", "Histamine receptors", true, "[true,true,true]", 5184, "gene with protein product", "NM_007232", "[\"GPCR97\"]", "Q9Y5N1" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 192028489310176698L, "histamine receptor H2", "HRH2", "5q35.2", "ENSG00000113749", "", "Histamine receptors", true, "[true,true,true]", 5183, "gene with protein product", "NM_001131055", "[]", "P25021" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7194941399694576270L, "histamine receptor H1", "HRH1", "3p25.3", "ENSG00000196639", "", "Histamine receptors", true, "[true,true,true]", 5182, "gene with protein product", "NM_000861", "[]", "P35367" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6470235976399534101L, "gamma-aminobutyric acid type B receptor subunit 1", "GABBR1", "6p22.1", "ENSG00000204681", "Y11044", "Gamma-aminobutyric acid type B receptor subunits", true, "[true,true,true]", 4070, "gene with protein product", "NM_001319053", "[\"\\\"GABA-B receptor\\\"\",\"GPRC3A\",\"hGB1a\"]", "Q9UBS5" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -322274143702374888L, "endothelin receptor type A", "EDNRA", "4q31.22-q31.23", "ENSG00000151617", "D90348", "Endothelin receptors", true, "[true,true,true]", 3179, "gene with protein product", "NM_001166055", "[\"ET-A\",\"ETA-R\",\"hET-AR\"]", "P25101" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7355868205587995583L, "dopamine receptor D5", "DRD5", "4p16.1", "ENSG00000169676", "X58454", "Dopamine receptors", true, "[true,true,true]", 3026, "gene with protein product", "NM_000798", "[\"DRD1B\"]", "P21918" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5762081417363923323L, "mitogen-activated protein kinase 7", "MAPK7", "17p11.2", "ENSG00000166484", "U25278", "Mitogen-activated protein kinases,Armadillo-like helical domain containing", true, "[true,false,false]", 6880, "gene with protein product", "NM_139033", "[\"BMK1 kinase\",\"extracellular-signal-regulated kinase 5\"]", "Q13164" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6172745099164718141L, "dopamine receptor D4", "DRD4", "11p15.5", "ENSG00000069696", "L12398", "Dopamine receptors", true, "[true,true,true]", 3025, "gene with protein product", "NM_000797", "[]", "P21917" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4328599311936128614L, "dopamine receptor D2", "DRD2", "11q23.2", "ENSG00000149295", "M29066", "Dopamine receptors", true, "[true,true,true]", 3023, "gene with protein product", "NM_000795", "[]", "P14416" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7156257108650939421L, "dopamine receptor D1", "DRD1", "5q35.2", "ENSG00000184845", "X55760", "Dopamine receptors", true, "[true,true,true]", 3020, "gene with protein product", "NM_000794", "[]", "P21728" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1607490301616936071L, "cysteinyl leukotriene receptor 1", "CYSLTR1", "Xq21.1", "ENSG00000173198", "AF119711", "Leukotriene receptors", true, "[true,true,true]", 17451, "gene with protein product", "NM_001282186", "[\"CysLT(1)\",\"CysLT1\",\"CYSLT1R\"]", "Q9Y271" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6020458314499309510L, "C-X-C motif chemokine receptor 4", "CXCR4", "2q22.1", "ENSG00000121966", "AF005058", "CD molecules", true, "[true,true,true]", 2561, "gene with protein product", "NM_001008540", "[\"CD184\",\"D2S201E\",\"fusin\",\"HM89\",\"HSY3RR\",\"LESTR\",\"NPY3R\",\"NPYR\",\"NPYY3R\"]", "P61073" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -340404777556110550L, "C-X-C motif chemokine receptor 3", "CXCR3", "Xq13.1", "ENSG00000186810", "U32674", "CD molecules", true, "[true,true,true]", 4540, "gene with protein product", "NM_001142797", "[\"CD183\",\"CKR-L2\",\"CMKAR3\",\"IP10-R\",\"MigR\"]", "P49682" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6317933954194481745L, "C-X-C motif chemokine receptor 2", "CXCR2", "2q35", "ENSG00000180871", "U11869", "CD molecules", true, "[true,true,true]", 6027, "gene with protein product", "NM_001557", "[\"CD182\",\"CMKAR2\"]", "P25025" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4255562651775115376L, "C-X-C motif chemokine receptor 1", "CXCR1", "2q35", "ENSG00000163464", "U11870", "CD molecules", true, "[true,true,true]", 6026, "gene with protein product", "NM_000634", "[\"CD181\",\"CDw128a\",\"CKR-1\"]", "P25024" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7502403980414073376L, "C-C motif chemokine receptor 5 (gene/pseudogene)", "CCR5", "3p21.31", "ENSG00000160791", "", "CD molecules", true, "[true,true,true]", 1606, "gene with protein product", "NM_000579", "[\"CC-CKR-5\",\"CD195\",\"CKR-5\",\"CKR5\",\"IDDM22\"]", "P51681" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -313531064682280404L, "C-C motif chemokine receptor 4", "CCR4", "3p22.3", "ENSG00000183813", "X85740", "CD molecules", true, "[true,true,true]", 1605, "gene with protein product", "NM_005508", "[\"CC-CKR-4\",\"CD194\",\"ChemR13\",\"CKR4\",\"CMKBR4\",\"k5-5\"]", "P51679" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2240038088131975176L, "C-C motif chemokine receptor 2", "CCR2", "3p21.31", "ENSG00000121807", "", "CD molecules", true, "[true,true,true]", 1603, "gene with protein product", "NM_000647", "[\"CC-CKR-2\",\"CD192\",\"CKR2\",\"FLJ78302\",\"MCP-1-R\"]", "P41597" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8873348983114395794L, "C-C motif chemokine receptor 1", "CCR1", "3p21.31", "ENSG00000163823", "", "CD molecules", true, "[true,true,true]", 1602, "gene with protein product", "NM_001295", "[\"CD191\",\"CKR-1\",\"MIP1aR\"]", "P32246" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4561809384593577506L, "cholecystokinin B receptor", "CCKBR", "11p15.4", "ENSG00000110148", "D13305", "Cholecystokinin receptors", true, "[true,true,true]", 1571, "gene with protein product", "NM_176875", "[]", "P32239" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5546745299095874876L, "dopamine receptor D3", "DRD3", "3q13.31", "ENSG00000151577", "", "Dopamine receptors", true, "[true,true,true]", 3024, "gene with protein product", "NM_000796.3", "[]", "P35462" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1223676544608965110L, "arachidonate 5-lipoxygenase", "ALOX5", "10q11.21", "ENSG00000012779", "J03571", "Arachidonate lipoxygenases", true, "[true,false,false]", 435, "gene with protein product", "NM_000698", "[]", "P09917" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5354273970710282749L, "phosphatidylinositol-4,5-bisphosphate 3-kinase catalytic subunit gamma", "PIK3CG", "7q22.3", "ENSG00000105851", "", "Phosphatidylinositol 3-kinase subunits", true, "[true,false,false]", 8978, "gene with protein product", "NM_001282426", "[]", "P48736" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5282746325148266565L, "amyloid beta precursor protein", "APP", "21q21.3", "ENSG00000142192", "M15533", "Endogenous ligands", true, "[true,false,false]", 620, "gene with protein product", "NM_000484", "[\"peptidase nexin-II\"]", "P05067" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4765982287196917605L, "cytochrome P450 family 3 subfamily A member 5", "CYP3A5", "7q22.1", "ENSG00000106258", "L26985", "Cytochrome P450 family 3", true, "[true,false,false]", 2638, "gene with protein product", "NM_000777", "[]", "P20815" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3272334591875913539L, "major histocompatibility complex, class II, DR beta 1", "HLA-DRB1", "6p21.32", "ENSG00000196126", "AJ297583", "C1-set domain containing,Histocompatibility complex", true, "[true,false,false]", 4948, "gene with protein product", "NM_002124", "[]", "P01911" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6782637612325222856L, "mitogen-activated protein kinase kinase 2", "MAP2K2", "19p13.3", "ENSG00000126934", "L11285", "Mitogen-activated protein kinase kinases", true, "[true,false,false]", 6842, "gene with protein product", "NM_030662", "[]", "P36507" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7369582881518299784L, "LIM domain kinase 1", "LIMK1", "7q11.23", "ENSG00000106683", "D26309", "LIM domain containing,PDZ domain containing,LIMK/TESK kinase family", true, "[true,false,false]", 6613, "gene with protein product", "NM_002314", "[]", "P53667" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6916685026388129549L, "matrix metallopeptidase 7", "MMP7", "11q22.2", "ENSG00000137673", "Z11887", "M10 matrix metallopeptidases", true, "[true,false,false]", 7174, "gene with protein product", "NM_002423", "[\"matrilysin\"]", "P09237" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1345451981244420546L, "glutathione S-transferase theta 1", "GSTT1", "22q11.23 alternate reference locus", "ENSG00000277656", "KI270879", "Soluble glutathione S-transferases", true, "[true,false,false]", 4641, "gene with protein product", "NM_000853", "[]", "P30711" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4564805480393646670L, "casein kinase 1 alpha 1", "CSNK1A1", "5q32", "ENSG00000113712", "AF119911", "", true, "[true,false,false]", 2451, "gene with protein product", "NM_001892", "[\"clock regulator kinase\"]", "P48729" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5240536317579929397L, "cyclin dependent kinase 1", "CDK1", "10q21.2", "ENSG00000170312", "BC014563", "Cyclin dependent kinases", true, "[true,false,false]", 1722, "gene with protein product", "NM_001786", "[]", "P06493" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6654563057512207163L, "cytochrome P450 family 2 subfamily C member 9", "CYP2C9", "10q23.33", "ENSG00000138109", "M61855", "Cytochrome P450 family 2", true, "[true,false,false]", 2623, "gene with protein product", "NM_000771", "[]", "P11712" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8550413589839769867L, "glucose-6-phosphate dehydrogenase", "G6PD", "Xq28", "ENSG00000160211", "X03674", "", true, "[true,false,false]", 4057, "gene with protein product", "NM_000402", "[]", "P11413" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3308049488675676274L, "protein kinase C alpha", "PRKCA", "17q24.2", "ENSG00000154229", "", "C2 domain containing protein kinases,AGC family kinases", true, "[true,false,false]", 9393, "gene with protein product", "NM_002737", "[]", "P17252" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3207368831859163390L, "glucokinase regulator", "GCKR", "2p23.3", "ENSG00000084734", "Z48475", "", true, "[true,false,false]", 4196, "gene with protein product", "NM_001486", "[\"hexokinase 4 regulator\"]", "Q14397" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6624585759544740499L, "progesterone receptor", "PGR", "11q22.1", "ENSG00000082175", "M15716", "Nuclear hormone receptors", true, "[true,false,false]", 8910, "gene with protein product", "NM_000926", "[]", "P06401" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3808668994028049281L, "GNAS complex locus", "GNAS", "20q13.32", "ENSG00000087460", "M21142", "G protein subunits alpha, group s,Granins", true, "[true,false,false]", 4392, "gene with protein product", "NM_000516", "[\"secretogranin VI\",\"G protein subunit alpha S\"]", "O95467" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6217911333730989461L, "protein kinase C beta", "PRKCB", "16p12.2-p12.1", "ENSG00000166501", "M13975", "C2 domain containing protein kinases,AGC family kinases", true, "[true,false,false]", 9395, "gene with protein product", "NM_212535", "[]", "P05771" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6249654149700210537L, "amyloid P component, serum", "APCS", "1q23.2", "ENSG00000132703", "", "Short pentraxins", true, "[true,false,false]", 584, "gene with protein product", "NM_001639", "[\"pentraxin-related\",\"9.5S alpha-1-glycoprotein\",\"pentraxin-2\"]", "P02743" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 9159890005578410233L, "protein kinase C eta", "PRKCH", "14q23.1", "ENSG00000027075", "M55284", "C2 domain containing protein kinases,AGC family kinases", true, "[true,false,false]", 9403, "gene with protein product", "NM_006255", "[]", "P24723" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5692690890054292296L, "Janus kinase 2", "JAK2", "9p24.1", "ENSG00000096968", "", "Jak family tyrosine kinases,SH2 domain containing,FERM domain containing", true, "[true,false,false]", 6192, "gene with protein product", "NM_001322194", "[]", "O60674" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3671309681483930361L, "ADAM metallopeptidase with thrombospondin type 1 motif 5", "ADAMTS5", "21q21.3", "ENSG00000154736", "AF142099", "ADAM metallopeptidases with thrombospondin type 1 motif", true, "[true,false,false]", 221, "gene with protein product", "NM_007038", "[\"aggrecanase-2\"]", "Q9UNA0" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4514698817640071081L, "protein kinase C theta", "PRKCQ", "10p15.1", "ENSG00000065675", "L07032", "C2 domain containing protein kinases,AGC family kinases", true, "[true,false,false]", 9410, "gene with protein product", "NM_006257", "[]", "Q04759" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7897332928751540974L, "matrix metallopeptidase 9", "MMP9", "20q13.12", "ENSG00000100985", "", "M10 matrix metallopeptidases", true, "[true,false,false]", 7176, "gene with protein product", "NM_004994", "[]", "P14780" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5893698841390112007L, "AKT serine/threonine kinase 2", "AKT2", "19q13.2", "ENSG00000105221", "M77198", "Pleckstrin homology domain containing,AGC family kinases", true, "[true,false,false]", 392, "gene with protein product", "NM_001626", "[]", "P31751" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 92635602492349795L, "5'-nucleotidase ecto", "NT5E", "6q14.3", "ENSG00000135318", "X55740", "5'-nucleotidases,CD molecules", true, "[true,false,false]", 8021, "gene with protein product", "NM_001204813", "[]", "P21589" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5685980426309008514L, "estrogen receptor 2", "ESR2", "14q23.2-q23.3", "ENSG00000140009", "X99101", "Nuclear hormone receptors", true, "[true,false,false]", 3468, "gene with protein product", "NM_001040275", "[\"ER beta\",\"estrogen receptor beta\",\"oestrogen receptor beta\",\"nuclear receptor subfamily 3 group A member 2\"]", "Q92731" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2530063109835246721L, "aldo-keto reductase family 1 member B10", "AKR1B10", "7q33", "ENSG00000198074", "AF052577", "Aldo-keto reductases", true, "[true,false,false]", 382, "gene with protein product", "NM_020299", "[\"aldose reductase-like 1\",\"aldo-keto reductase family 1\",\"member B11 (aldose reductase-like)\",\"aldose reductase-like peptide\",\"aldose reductase-related protein\",\"small intestine reductase\"]", "O60218" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6504235370078468148L, "cyclin dependent kinase 6", "CDK6", "7q21.2", "ENSG00000105810", "", "Cyclin dependent kinases", true, "[true,false,false]", 1777, "gene with protein product", "NM_001145306", "[]", "Q00534" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5690102112298626048L, "heme oxygenase 1", "HMOX1", "22q12.3", "ENSG00000100292", "", "", true, "[true,false,false]", 5013, "gene with protein product", "NM_002133", "[]", "P09601" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7176798632262366451L, "bone morphogenetic protein receptor type 1B", "BMPR1B", "4q22.3", "ENSG00000138696", "D89675", "Type 1 receptor serine/threonine kinases,CD molecules", true, "[true,false,false]", 1077, "gene with protein product", "NM_001203", "[]", "O00238" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5128551280530470578L, "G protein-coupled receptor kinase 4", "GRK4", "4p16.3", "ENSG00000125388", "", "AGC family kinases", true, "[true,false,false]", 4543, "gene with protein product", "NM_005307", "[]", "P32298" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -357021598393618359L, "insulin receptor", "INSR", "19p13.2", "ENSG00000171105", "M10051", "CD molecules,Fibronectin type III domain containing,Receptor tyrosine kinases", true, "[true,false,false]", 6091, "gene with protein product", "NM_000208", "[]", "P06213" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5625918046394701078L, "advanced glycosylation end-product specific receptor", "AGER", "6p21.32", "ENSG00000204305", "M91211", "Immunoglobulin like domain containing,Scavenger receptors,C2-set domain containing", true, "[true,false,false]", 320, "gene with protein product", "NM_001136", "[\"receptor for advanced glycation end-products\"]", "Q15109" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -794848552298848528L, "leukotriene A4 hydrolase", "LTA4H", "12q23.1", "ENSG00000111144", "BC032528", "M1 metallopeptidases", true, "[true,false,false]", 6710, "gene with protein product", "NM_000895", "[]", "P09960" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3850981839906694106L, "dipeptidyl peptidase 4", "DPP4", "2q24.2", "ENSG00000197635", "M74777", "DASH family,CD molecules", true, "[true,false,false]", 3009, "gene with protein product", "NM_001935", "[]", "P27487" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3541996098569967287L, "orosomucoid 2", "ORM2", "9q32", "ENSG00000228278", "", "Lipocalins", true, "[true,false,false]", 8499, "gene with protein product", "NM_000608", "[\"alpha-1-acid glycoprotein\",\"type 2\"]", "P19652" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2892427189902344979L, "phosphodiesterase 2A", "PDE2A", "11q13.4", "ENSG00000186642", "U67733", "Phosphodiesterases", true, "[true,false,false]", 8777, "gene with protein product", "NM_002599", "[]", "O00408" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5620214912540731773L, "ribosomal protein S6 kinase A3", "RPS6KA3", "Xp22.12", "ENSG00000177189", "U08316", "X-linked mental retardation,Mitogen-activated protein kinase-activated protein kinases,AGC family kinases", true, "[true,false,false]", 10432, "gene with protein product", "NM_004586", "[]", "P51812" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2373028744469597576L, "casein kinase 2 alpha 1", "CSNK2A1", "20p13", "ENSG00000101266", "M55265", "", true, "[true,false,false]", 2457, "gene with protein product", "NM_001895", "[\"Casein kinase II subunit alpha\"]", "P68400" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3119971976504122629L, "ret proto-oncogene", "RET", "10q11.21", "ENSG00000165731", "BC004257", "Cadherin related,Receptor tyrosine kinases", true, "[true,false,false]", 9967, "gene with protein product", "NM_020975", "[\"cadherin-related family member 16\",\"RET receptor tyrosine kinase\",\"rearranged during transfection\"]", "P07949" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1434515667130507079L, "ribonucleotide reductase catalytic subunit M1", "RRM1", "11p15.4", "ENSG00000167325", "X59543", "", true, "[true,false,false]", 10451, "gene with protein product", "NM_001033", "[]", "P23921" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4675332513257462025L, "LYN proto-oncogene, Src family tyrosine kinase", "LYN", "8q12.1", "ENSG00000254087", "M16038", "SH2 domain containing,Src family tyrosine kinases", true, "[true,false,false]", 6735, "gene with protein product", "NM_002350", "[]", "P07948" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2881801192825125864L, "cytochrome P450 family 2 subfamily C member 8", "CYP2C8", "10q23.33", "ENSG00000138115", "M17397", "Cytochrome P450 family 2", true, "[true,false,false]", 2622, "gene with protein product", "NM_000770", "[]", "P10632" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7111708069207429003L, "mitogen-activated protein kinase kinase kinase 8", "MAP3K8", "10p11.23", "ENSG00000107968", "D14497", "Mitogen-activated protein kinase kinase kinases", true, "[true,false,false]", 6860, "gene with protein product", "NM_005204", "[]", "P41279" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 1491572744015624627L, "SRC proto-oncogene, non-receptor tyrosine kinase", "SRC", "20q11.23", "ENSG00000197122", "AF077754", "SH2 domain containing,Src family tyrosine kinases", true, "[true,false,false]", 11283, "gene with protein product", "NM_005417", "[]", "P12931" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -714307572884120194L, "macrophage migration inhibitory factor", "MIF", "22q11.23", "ENSG00000240972", "M25639", "", true, "[true,false,false]", 7097, "gene with protein product", "NM_002415", "[\"glycosylation-inhibiting factor\",\"phenylpyruvate tautomerase\"]", "P14174" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6357186567031349008L, "glutaminyl-peptide cyclotransferase", "QPCT", "2p22.2", "ENSG00000115828", "X71125", "", true, "[true,false,false]", 9753, "gene with protein product", "NM_012413", "[\"glutaminyl cyclase\"]", "Q16769" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7766239906051167220L, "elastase, neutrophil expressed", "ELANE", "19p13.3", "ENSG00000197561", "", "Granule associated serine proteases of immune defence,Complement system regulators and receptors", true, "[true,false,false]", 3309, "gene with protein product", "NM_001972", "[\"neutrophil elastase\",\"leukocyte elastase\",\"medullasin\"]", "P08246" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7845041277778665622L, "nitric oxide synthase 3", "NOS3", "7q36.1", "ENSG00000164867", "", "", true, "[true,false,false]", 7876, "gene with protein product", "NM_000603", "[\"endothelial nitric oxide synthase\"]", "P29474" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7931926827855957589L, "Janus kinase 1", "JAK1", "1p31.3", "ENSG00000162434", "M64174", "Jak family tyrosine kinases,FERM domain containing", true, "[true,false,false]", 6190, "gene with protein product", "NM_002227", "[]", "P23458" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6533543332171458654L, "glutathione S-transferase alpha 1", "GSTA1", "6p12.2", "ENSG00000243955", "", "Soluble glutathione S-transferases", true, "[true,false,false]", 4626, "gene with protein product", "NM_001319059", "[]", "P08263" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8994418009290318854L, "inhibitor of nuclear factor kappa B kinase subunit beta", "IKBKB", "8p11.21", "ENSG00000104365", "AF029684", "", true, "[true,false,false]", 5960, "gene with protein product", "NM_001190720", "[]", "O14920" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2531066201406511374L, "matrix metallopeptidase 8", "MMP8", "11q22.2", "ENSG00000118113", "J05556", "M10 matrix metallopeptidases", true, "[true,false,false]", 7175, "gene with protein product", "NM_002424", "[]", "P22894" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4369970850947997004L, "glutathione S-transferase alpha 4", "GSTA4", "6p12.2", "ENSG00000170899", "AF020918", "Soluble glutathione S-transferases", true, "[true,false,false]", 4629, "gene with protein product", "NM_001512", "[]", "O15217" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8999241017923668819L, "D-amino acid oxidase", "DAO", "12q24.11", "ENSG00000110887", "D11370", "", true, "[true,false,false]", 2671, "gene with protein product", "NM_001917", "[]", "P14920" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1250343043723760016L, "cholinergic receptor nicotinic alpha 7 subunit", "CHRNA7", "15q13.3", "ENSG00000175344", "Z23141", "Cholinergic receptors nicotinic subunits", true, "[true,false,false]", 1960, "gene with protein product", "NM_000746", "[\"acetylcholine receptor\",\"nicotinic\",\"alpha 7 (neuronal)\"]", "P36544" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3585510100144398938L, "thymidine kinase 1", "TK1", "17q25.3", "ENSG00000167900", "", "", true, "[true,false,false]", 11830, "gene with protein product", "NM_003258", "[]", "P04183" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2732530428526337854L, "glutamate ionotropic receptor AMPA type subunit 2", "GRIA2", "4q32.1", "ENSG00000120251", "", "Glutamate ionotropic receptor AMPA type subunits", true, "[true,false,false]", 4572, "gene with protein product", "NM_000826", "[]", "P42262" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6919712082615358260L, "neuropilin 1", "NRP1", "10p11.22", "ENSG00000099250", "AF016050", "CD molecules", true, "[true,false,false]", 8004, "gene with protein product", "NM_001024628", "[]", "O14786" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -400370360835740696L, "NEDD8 activating enzyme E1 subunit 1", "NAE1", "16q22.1", "ENSG00000159593", "U50939", "Ubiquitin like modifier activating enzymes", true, "[true,false,false]", 621, "gene with protein product", "NM_003905", "[]", "Q13564" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7712027088830515774L, "lactate dehydrogenase A", "LDHA", "11p15.1", "ENSG00000134333", "X02152", "", true, "[true,false,false]", 6535, "gene with protein product", "NM_005566", "[]", "P00338" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -3990557132708298675L, "farnesyltransferase, CAAX box, alpha", "FNTA", "8p11.21", "ENSG00000168522", "L10413", "Prenyltransferase alpha subunit repeat containing", true, "[true,false,false]", 3782, "gene with protein product", "NM_002027", "[\"protein prenyltransferase alpha subunit repeat containing 2\",\"protein farnesyltransferase/geranylgeranyltransferase type-1 subunit alpha\"]", "P49354" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6809730074072730564L, "Rho associated coiled-coil containing protein kinase 2", "ROCK2", "2p25.1", "ENSG00000134318", "D87931", "Pleckstrin homology domain containing,AGC family kinases", true, "[true,false,false]", 10252, "gene with protein product", "NM_001321643", "[]", "O75116" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7870338846549177528L, "Rho associated coiled-coil containing protein kinase 1", "ROCK1", "18q11.1", "ENSG00000067900", "", "Pleckstrin homology domain containing,AGC family kinases", true, "[true,false,false]", 10251, "gene with protein product", "NM_005406", "[]", "Q13464" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3501835402182058104L, "G protein-coupled receptor kinase 2", "GRK2", "11q13.2", "ENSG00000173020", "X61157", "Pleckstrin homology domain containing,AGC family kinases", true, "[true,false,false]", 289, "gene with protein product", "NM_001619", "[]", "P25098" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7528375525065502317L, "discoidin domain receptor tyrosine kinase 1", "DDR1", "6p21.33", "ENSG00000204580", "X99031", "CD molecules,Receptor tyrosine kinases", true, "[true,false,false]", 2730, "gene with protein product", "NM_013994", "[]", "Q08345" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8127383949220762034L, "activin A receptor type 2A", "ACVR2A", "2q22.3-q23.1", "ENSG00000121989", "", "Type 2 receptor serine/threonine kinases", true, "[true,false,false]", 173, "gene with protein product", "NM_001616", "[]", "P27037" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7149672510980652364L, "thyroid hormone receptor alpha", "THRA", "17q21.1", "ENSG00000126351", "J03239", "Nuclear hormone receptors", true, "[true,false,false]", 11796, "gene with protein product", "NM_001190918", "[]", "P10827" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4061029732997495396L, "nuclear receptor subfamily 1 group H member 3", "NR1H3", "11p11.2", "ENSG00000025434", "U22662", "Nuclear hormone receptors", true, "[true,false,false]", 7966, "gene with protein product", "NM_001130101", "[\"liver X receptor-alpha\"]", "Q13133" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4196803465763616779L, "amine oxidase, copper containing 3", "AOC3", "17q21.31", "ENSG00000131471", "AF067406", "", true, "[true,false,false]", 550, "gene with protein product", "NM_003734", "[\"vascular adhesion protein 1\"]", "Q16853" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7638499126655098847L, "polo like kinase 2", "PLK2", "5q11.2", "ENSG00000145632", "", "", true, "[true,false,false]", 19699, "gene with protein product", "NM_006622", "[\"serum-inducible kinase\"]", "Q9NYY3" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5136835108294046406L, "hyperpolarization activated cyclic nucleotide gated potassium channel 4", "HCN4", "15q24.1", "ENSG00000138622", "AJ132429", "Cyclic nucleotide gated channels", true, "[true,false,false]", 16882, "gene with protein product", "NM_005477", "[]", "Q9Y3Q4" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4057107023626730533L, "caspase 8", "CASP8", "2q33.1", "ENSG00000064012", "U60520", "Caspases,Death effector domain containing,Ripoptosome,Death inducing signaling complex ", true, "[true,false,false]", 1509, "gene with protein product", "NM_001228", "[]", "Q14790" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2096298662933259430L, "caspase 9", "CASP9", "1p36.21", "ENSG00000132906", "U60521", "Protein phosphatase 1 regulatory subunits,Caspases,Apoptosome,Caspase recruitment domain containing", true, "[true,false,false]", 1511, "gene with protein product", "NM_032996", "[\"protein phosphatase 1\",\"regulatory subunit 56\"]", "P55211" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4075572146005004421L, "angiotensin I converting enzyme", "ACE", "17q23.3", "ENSG00000159640", "J04144", "CD molecules", true, "[true,false,false]", 2707, "gene with protein product", "NM_000789", "[\"peptidyl-dipeptidase A\"]", "P12821" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5392816744904412311L, "caspase 3", "CASP3", "4q35.1", "ENSG00000164305", "BC016926", "Caspases", true, "[true,false,false]", 1504, "gene with protein product", "NM_004346", "[]", "P42574" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7267986353716459050L, "heat shock protein 90 beta family member 1", "HSP90B1", "12q23.3", "ENSG00000166598", "AY040226", "Heat shock 90kDa proteins", true, "[true,false,false]", 12028, "gene with protein product", "NM_003299", "[\"endoplasmin\"]", "P14625" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -2639947672187558274L, "caspase 1", "CASP1", "11q22.3", "ENSG00000137752", "U13697", "Caspases,Caspase recruitment domain containing", true, "[true,false,false]", 1499, "gene with protein product", "NM_033292", "[\"caspase-1\",\"interleukin 1\",\"beta\",\"convertase\"]", "P29466" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8705580512939524064L, "cyclin dependent kinase 3", "CDK3", "17q25.1", "ENSG00000250506", "X66357", "Cyclin dependent kinases", true, "[true,false,false]", 1772, "gene with protein product", "NM_001258", "[]", "Q00526" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4881848234302395176L, "nuclear receptor coactivator 1", "NCOA1", "2p23.3", "ENSG00000084676", "U40396", "Basic helix-loop-helix proteins,Lysine acetyltransferases", true, "[true,false,false]", 7668, "gene with protein product", "NM_147223", "[]", "Q15788" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3583930527454162925L, "methylenetetrahydrofolate dehydrogenase, cyclohydrolase and formyltetrahydrofolate synthetase 1", "MTHFD1", "14q23.3", "ENSG00000100714", "J04031", "Minor histocompatibility antigens", true, "[true,false,false]", 7432, "gene with protein product", "NM_005956", "[]", "P11586" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3541138320624082963L, "protein tyrosine phosphatase, non-receptor type 11", "PTPN11", "12q24.13", "ENSG00000179295", "D13540", "Protein tyrosine phosphatases, non-receptor type,SH2 domain containing", true, "[true,false,false]", 9644, "gene with protein product", "NM_001330437", "[]", "Q06124" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2054371802701840028L, "ELAV like RNA binding protein 1", "ELAVL1", "19p13.2", "ENSG00000066044", "U38175", "RNA binding motif containing", true, "[true,false,false]", 3312, "gene with protein product", "NM_001419", "[\"embryonic lethal\",\"abnormal vision\",\"drosophila\",\"homolog-like 1\",\"Hu antigen R\"]", "Q15717" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5103570257027706965L, "dihydrofolate reductase", "DHFR", "5q14.1", "ENSG00000228716", "", "", true, "[true,false,false]", 2861, "gene with protein product", "NM_000791", "[]", "P00374" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6132881191813973961L, "coagulation factor VIII", "F8", "Xq28", "ENSG00000185010", "M90707", "", true, "[true,false,false]", 3546, "gene with protein product", "NM_000132", "[\"Factor VIIIF8B\",\"hemophilia A\"]", "P00451" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6564615845093927035L, "furin, paired basic amino acid cleaving enzyme", "FURIN", "15q26.1", "ENSG00000140564", "X17094", "Proprotein convertase subtilisin/kexin family", true, "[true,false,false]", 8568, "gene with protein product", "NM_002569", "[]", "P09958" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6767911387966177009L, "kinase insert domain receptor", "KDR", "4q12", "ENSG00000128052", "AF035121", "Immunoglobulin like domain containing,I-set domain containing,CD molecules,V-set domain containing,Receptor tyrosine kinases", true, "[true,false,false]", 6307, "gene with protein product", "NM_002253", "[\"vascular endothelial growth factor receptor 2\",\"fetal liver kinase 1\"]", "P35968" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7933481855003762391L, "chitinase 1", "CHIT1", "1q32.1", "ENSG00000133063", "U29615", "Chitinases", true, "[true,false,false]", 1936, "gene with protein product", "NM_003465", "[\"chitotriosidase\"]", "Q13231" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4705266176965428530L, "kinesin family member 3C", "KIF3C", "2p23.3", "ENSG00000084731", "", "Kinesins", true, "[true,false,false]", 6321, "gene with protein product", "NM_002254", "[]", "O14782" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 884344361116801768L, "hepatocyte nuclear factor 4 alpha", "HNF4A", "20q13.12", "ENSG00000101076", "X76930", "Nuclear hormone receptors", true, "[true,false,false]", 5024, "gene with protein product", "NM_000457", "[]", "P41235" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 2667319154618118024L, "ATP binding cassette subfamily C member 8", "ABCC8", "11p15.1", "ENSG00000006071", "L78207", "ATP binding cassette subfamily C", true, "[true,false,false]", 59, "gene with protein product", "NM_000352", "[\"sulfonylurea receptor (hyperinsulinemia)\"]", "Q09428" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 384545282557665715L, "cathepsin K", "CTSK", "1q21.3", "ENSG00000143387", "BC016058", "Cathepsins", true, "[true,false,false]", 2536, "gene with protein product", "NM_000396", "[]", "P43235" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8841770264975615210L, "cytochrome P450 family 2 subfamily C member 19", "CYP2C19", "10q23.33", "ENSG00000165841", "M61854", "Cytochrome P450 family 2", true, "[true,false,false]", 2621, "gene with protein product", "NM_000769", "[]", "P33261" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4459941632345872523L, "hemoglobin subunit beta", "HBB", "11p15.4", "ENSG00000244734", "J00173", "Hemoglobin subunits", true, "[true,false,false]", 4827, "gene with protein product", "NM_000518", "[]", "P68871" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -6000688301986983627L, "mitogen-activated protein kinase-activated protein kinase 2", "MAPKAPK2", "1q32.1", "ENSG00000162889", "U12779", "Mitogen-activated protein kinase-activated protein kinases", true, "[true,false,false]", 6887, "gene with protein product", "NM_004759", "[]", "P49137" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7522824653079210479L, "ATP binding cassette subfamily C member 1", "ABCC1", "16p13.11", "ENSG00000103222", "L05628", "ATP binding cassette subfamily C", true, "[true,false,false]", 51, "gene with protein product", "NM_004996", "[]", "P33527" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -1752700118769675978L, "cyclin dependent kinase 9", "CDK9", "9q34.11", "ENSG00000136807", "L25676", "Cyclin dependent kinases,P-TEFb complex subunits", true, "[true,false,false]", 1780, "gene with protein product", "NM_001261", "[]", "P50750" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5046484250013168279L, "endothelin receptor type B", "EDNRB", "13q22.3", "ENSG00000136160", "L06623", "Endothelin receptors", true, "[true,false,false]", 3180, "gene with protein product", "NM_000115", "[]", "P24530" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7729373771782511375L, "cytochrome P450 family 2 subfamily E member 1", "CYP2E1", "10q26.3", "ENSG00000130649", "J02843", "Cytochrome P450 family 2", true, "[true,false,false]", 2631, "gene with protein product", "NM_000773", "[]", "P05181" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8811357979219904563L, "ras homolog family member A", "RHOA", "3p21.31", "ENSG00000067560", "BC001360", "Rho family GTPases", true, "[true,false,false]", 667, "gene with protein product", "NM_001664", "[]", "P61586" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4947616947612923137L, "cathepsin B", "CTSB", "8p23.1", "ENSG00000164733", "M14221", "Cathepsins", true, "[true,false,false]", 2527, "gene with protein product", "NM_147780", "[]", "P07858" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -210252616925803098L, "purinergic receptor P2Y1", "P2RY1", "3q25.2", "ENSG00000169860", "U42029", "P2Y receptors", true, "[true,false,false]", 8539, "gene with protein product", "NM_002563", "[\"suppressing androgen receptor in renal cell carcinoma\"]", "P47900" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7061920066983768124L, "chymase 1", "CMA1", "14q12", "ENSG00000092009", "", "Granule associated serine proteases of immune defence", true, "[true,false,false]", 2097, "gene with protein product", "NM_001836", "[]", "P23946" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 5408390997510554072L, "integrin subunit beta 7", "ITGB7", "12q13.13", "ENSG00000139626", "", "Integrin beta subunits", true, "[true,false,false]", 6162, "gene with protein product", "NM_000889", "[]", "P26010" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -5859602178330779818L, "cytochrome P450 family 2 subfamily B member 6", "CYP2B6", "19q13.2", "ENSG00000197408", "AF182277", "Cytochrome P450 family 2", true, "[true,false,false]", 2615, "gene with protein product", "NM_000767", "[]", "P20813" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6030806797009414919L, "cytochrome P450 family 2 subfamily D member 6", "CYP2D6", "22q13.2", "ENSG00000100197", "M20403", "Cytochrome P450 family 2", true, "[true,false,false]", 2625, "gene with protein product", "NM_000106", "[]", "P10635" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -4879440063275753876L, "deoxyhypusine synthase", "DHPS", "19p13.13", "ENSG00000095059", "U79262", "", true, "[true,false,false]", 2869, "gene with protein product", "NM_001930", "[\"migration-inducing gene 13\"]", "P49366" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -7544785692657587891L, "glucokinase", "GCK", "7p13", "ENSG00000106633", "AF041014", "", true, "[true,false,false]", 4195, "gene with protein product", "NM_000162", "[\"hexokinase 4\"]", "P35557" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 7559037565658854262L, "cytochrome P450 family 19 subfamily A member 1", "CYP19A1", "15q21.2", "ENSG00000137869", "D14473", "Cytochrome P450 family 19", true, "[true,false,false]", 2594, "gene with protein product", "NM_000103", "[]", "P11511" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8176671561863922335L, "phosphatidylinositol-4,5-bisphosphate 3-kinase catalytic subunit alpha", "PIK3CA", "3q26.32", "ENSG00000121879", "", "Phosphatidylinositol 3-kinase subunits", true, "[true,false,false]", 8975, "gene with protein product", "NM_006218", "[]", "P42336" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -8357706395007423635L, "NAD(P)H quinone dehydrogenase 1", "NQO1", "16q22.1", "ENSG00000181019", "M81600", "", true, "[true,false,false]", 2874, "gene with protein product", "NM_000903", "[]", "P15559" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 3891620263162042002L, "matrix metallopeptidase 1", "MMP1", "11q22.2", "ENSG00000196611", "X54925", "M10 matrix metallopeptidases,Endogenous ligands", true, "[true,false,false]", 7155, "gene with protein product", "NM_002421", "[\"interstitial collagenase\"]", "P03956" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4402979137200077571L, "nitric oxide synthase 1", "NOS1", "12q24.22", "ENSG00000089250", "", "PDZ domain containing", true, "[true,false,false]", 7872, "gene with protein product", "NM_000620", "[]", "P29475" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 6184713140914290692L, "tumor protein p53", "TP53", "17p13.1", "ENSG00000141510", "AF307851", "", true, "[true,false,false]", 11998, "gene with protein product", "NM_000546", "[\"Li-Fraumeni syndrome\"]", "P04637" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8833615709177362898L, "hepatocyte nuclear factor 4 gamma", "HNF4G", "8q21.13", "ENSG00000164749", "", "Nuclear hormone receptors", true, "[true,false,false]", 5026, "gene with protein product", "NM_004133", "[]", "Q14541" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 8966464019536083462L, "insulin like growth factor 1 receptor", "IGF1R", "15q26.3", "ENSG00000140443", "M69229", "CD molecules,Fibronectin type III domain containing,Receptor tyrosine kinases", true, "[true,false,false]", 5465, "gene with protein product", "NM_000875", "[]", "P08069" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { -558574720700026552L, "protein tyrosine phosphatase, non-receptor type 22", "PTPN22", "1p13.2", "ENSG00000134242", "AF001846", "Protein tyrosine phosphatases, non-receptor type", true, "[true,false,false]", 9652, "gene with protein product", "NM_015967", "[]", "Q9Y2R2" });

            migrationBuilder.InsertData(
                table: "DockingProteins",
                columns: new[] { "Id", "ApprovedName", "ApprovedSymbol", "ChromosomalLocation", "EnsemblId", "GenBankId", "GeneFamily", "HasKnownLigands", "HasPockets", "HgncId", "LocusType", "NcbiId", "Synonyms", "UniProtId" },
                values: new object[] { 4681360241400536090L, "stratifin", "SFN", "1p36.11", "ENSG00000175793", "BC023552", "14-3-3 phospho-serine/phospho-threonine binding proteins", true, "[true,false,false]", 10773, "gene with protein product", "NM_006142", "[\"14-3-3 sigma\"]", "P31947" });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -1011270477136425037L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3731591095676979226L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6974341634385238706L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1600792638845990025L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3732836808458950942L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8871344038219058376L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7992529926321588240L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1252892664207953598L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3606856980312601334L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -87818609146488774L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1541457873568674976L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 377500572444435992L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -9128521183371756365L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1416867075874855836L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4268531097163778994L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1390479403806925448L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7877626049082496699L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7746961648860871356L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3637348440751533328L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4196737465056089450L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1240338334706334942L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3486129873678327719L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7248152018939117953L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5847597755706979002L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8488393433250885210L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2059476425741387707L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4871066599161628283L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2937038222490791199L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 552817079677848373L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5780002788493544135L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3893449195903294096L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7775320514256731712L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2296163120660145083L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 266948322105602135L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7300851850477672131L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -108765601467626317L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5046092238998303617L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3579127417806621264L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1962916074300918041L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7080576442467452282L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1835498613592835781L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7310032848217484074L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2888567970247837626L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8990962930432014842L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5446801401145374728L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5783770255334107633L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -591683670650865732L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1652440062800680466L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6441835835985977300L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3082058075461304994L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8314211214314705306L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3080343669100651568L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -166838914670404711L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2690523777657705330L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2400475259286814796L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5082567609285176849L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8512063516045336032L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8128611538873217362L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5577364513658075151L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7833691892390660488L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1523609009458026692L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4047910237243904126L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6694364658057075244L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4074068617093194307L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4856786093785805082L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6644534177223853402L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3027321970642692182L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4855687658952291570L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8202853664092594543L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6122269893740583545L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2998541208038749011L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6416581235290523177L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2096362753557469735L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2882068794292324800L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2941780911780750327L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8882406792480976448L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1298358004011320323L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4808289748145464505L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1166900776849744201L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8428139013121393655L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5460190876110622827L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3222058892820879647L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -357021598393618359L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5625918046394701078L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -794848552298848528L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3850981839906694106L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3541996098569967287L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8920140813000375529L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6884465304149252135L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7924795117474522259L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6193952907229243795L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3114185400287924179L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8439368411212131505L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7429245781809420632L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 580762822894835590L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8029969379815858125L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -9111210136835967353L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8969815508280037039L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3391048516841809013L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1198815245324831882L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -670717245265312635L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 864388842414647706L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8115463001070408666L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8991575294890443428L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8742174003728770588L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8538324753306470562L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1541553470328877920L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4178025057816367392L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5767965696690967919L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4723870892598290853L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2050545138202642574L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4774323977254777348L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3165318530856244256L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3286014952854004730L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2164972350581657011L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -227517515587540569L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8282918897315613729L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8234529567906223232L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7028841955294953643L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7110064130466762890L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5081325371871701341L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3145274452025931097L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5579014919104266194L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -905599235603354615L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5049699003963435050L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7874641701777122698L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2196486239926414644L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6794221876500488009L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5531825676035196783L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -9174313527596187483L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7518018316926652501L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8816185447602660839L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3501430381557928791L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2719515960030308739L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5393644031675907400L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -652404531438348698L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8899828626987360145L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4933218803741291348L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1868497937939581313L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3706403947399110904L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2367107532765053409L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8443682161072404958L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1875358783136948836L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1096905976741962589L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -836655376402262505L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2178381005042933731L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5708583372417341622L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1533829891749974269L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3279078642072290332L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3176824505865931761L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 319378812624435227L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3942096020644265609L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -64096387862235902L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5055223213953354960L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 466418287210643955L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5886027972297370267L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7020633545744679155L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6407724753413663221L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8185965384736935547L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -602500104778997899L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5616024887144011202L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4154543005689276688L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -306658287103020408L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2839488711434410816L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7626791815591738653L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7271386503413621600L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7869253853618088139L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5538299065142700633L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4690596245772934019L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2242414330299779124L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8505581847414489808L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3741045317082072732L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3526653529522139666L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -968323116932171173L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4113826880462165289L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5434750034275688544L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4038938137687233986L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2706602557455485085L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3223603088932536141L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1860378687312062720L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2892427189902344979L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1211540942351445484L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2164923636600567989L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3017416383587474580L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7458056271654969368L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7515564671800847140L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6595471962186604754L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5046769656126260384L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4306993936190403112L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 581978828847249191L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5996653262732456743L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -297014388601758531L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -677034654539159249L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2702269034664917480L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3276207780796304024L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2662126199465510133L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4777822714750551052L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6229417169330484651L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -955855002833216383L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -846720960733617492L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2078916802834698371L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5989283040142880941L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8937012576425917013L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3766953543599224750L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6946266493517979349L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8256052442709687961L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6519456723159858717L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 413160924379259371L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2820536956988273337L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2835683698691572728L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7286442021231424070L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8217599466527781050L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8672610739681665592L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -845697480161923433L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7942879173081689985L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -137485887315253818L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1715148413798868644L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5391536805684456842L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6297746589230566373L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5515557467982057572L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8324320231433162360L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2666711242041094845L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2099448898017149142L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -780486182335129183L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4220625135268562561L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4790809478792554689L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5749989344462949150L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8503359759198411895L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2523904323150379372L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3718266994377307792L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1978117211287056744L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8314325034680199370L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4536125327231651983L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5524720654063828505L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8232453929604150898L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5192006528371093992L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3985314229698254447L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4461831045071011463L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8441602990058020191L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2712453573791206566L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4549900727149064389L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6919712082615358260L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5620214912540731773L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3119971976504122629L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 1285800990388487622L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 8107184554923835698L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 8255296235676472749L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -6712022154609725180L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 8757030924402031580L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -7824885225118565229L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 6730625874099210208L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -5739238604861719704L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 6827465469318017189L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -5919513186250160125L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 4949204605683976708L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -3660840146811804490L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 2180131563124354864L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1627767953745793413L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 5151491594611410685L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 2444774081880887098L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 7089017631554039642L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -2483229631620007187L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 5812648385083634542L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 2959201505920494760L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4974100470931936590L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 4974100470931936590L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4265818074949461259L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 4265818074949461259L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -718657767516142007L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -258865047799651018L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 1627767953745793413L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 192028489310176698L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 4199027515256101549L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -4556375078662851464L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5313464769029762524L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2023810178841768308L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4883595599005139689L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5302977922417386818L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8687095776931538495L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4581394756164577178L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4162712006930991577L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -661819104833095392L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8450050534580037068L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2061277852396023855L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5347145832373205506L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -469991249225005575L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -8629079639376559678L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7500897822625621878L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8206449840496857318L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -8206449840496857318L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -2268982485882712052L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -2154481941514157632L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 8997054009694923741L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 3744922911417106480L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -6085629256296895668L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 8672482639517129554L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -8206411860240424270L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -3943084629894404857L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 1569061970222943319L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 6191195604262581560L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4042163546734634376L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7194941399694576270L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -7194941399694576270L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -6470235976399534101L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8194767268025886069L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 8194767268025886069L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 8657283579784734272L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 6366722946110467482L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -1372670201000926075L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 5535486562525788268L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -8557899630359207531L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -2755481282972892811L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5863638504500477864L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 5863638504500477864L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3166423890621111369L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -3166423890621111369L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 6144193946560537317L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 1008786115010631327L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -8216965585793044005L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 4367194148999708396L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5918464503077828884L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -5918464503077828884L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6305132363760067150L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 6305132363760067150L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 4271606637158677116L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -8618772611880551132L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -2960586528245383528L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 9150556276723070326L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2891508762551249936L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 2891508762551249936L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 8431991881175285893L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -1171941529448516172L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1171941529448516172L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 6885115091375445152L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -322274143702374888L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 7355868205587995583L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 6172745099164718141L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5546745299095874876L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -5546745299095874876L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4328599311936128614L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -4328599311936128614L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 7156257108650939421L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 1607490301616936071L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6020458314499309510L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 6020458314499309510L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -340404777556110550L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 6317933954194481745L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 4255562651775115376L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7502403980414073376L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -7502403980414073376L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -313531064682280404L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2240038088131975176L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 2240038088131975176L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 8873348983114395794L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -4561809384593577506L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 3195634977243934443L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -180786589000152212L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8397812296855956774L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -8397812296855956774L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, -2456961155520488105L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 1, 3280257464032361096L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2249604879658191454L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -9093983742726377489L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -291280646142093809L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5886512473682800861L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3308049488675676274L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3207368831859163390L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6624585759544740499L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3808668994028049281L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6217911333730989461L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6249654149700210537L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 9159890005578410233L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5692690890054292296L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3671309681483930361L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4514698817640071081L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7897332928751540974L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5893698841390112007L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8550413589839769867L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 92635602492349795L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2530063109835246721L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7111708069207429003L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -400370360835740696L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7061920066983768124L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7712027088830515774L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2667319154618118024L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 384545282557665715L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8841770264975615210L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4459941632345872523L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6000688301986983627L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7522824653079210479L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1752700118769675978L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5685980426309008514L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6654563057512207163L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5240536317579929397L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4564805480393646670L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1434515667130507079L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4675332513257462025L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2881801192825125864L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1491572744015624627L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2732530428526337854L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -714307572884120194L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6357186567031349008L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7766239906051167220L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7845041277778665622L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7931926827855957589L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6533543332171458654L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8994418009290318854L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2531066201406511374L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4369970850947997004L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8999241017923668819L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1250343043723760016L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3585510100144398938L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5128551280530470578L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7176798632262366451L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5690102112298626048L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6504235370078468148L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4765982287196917605L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3272334591875913539L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6782637612325222856L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7369582881518299784L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6916685026388129549L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1345451981244420546L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5046484250013168279L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2373028744469597576L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7729373771782511375L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4947616947612923137L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2096298662933259430L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4075572146005004421L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5392816744904412311L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7267986353716459050L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -2639947672187558274L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8705580512939524064L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4881848234302395176L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3583930527454162925L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3541138320624082963L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 2054371802701840028L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5103570257027706965L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6132881191813973961L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4057107023626730533L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6564615845093927035L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5354273970710282749L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 1223676544608965110L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5762081417363923323L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8336912603629409240L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -149420345163456575L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8037247376208615722L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -1450154453344748524L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8163353798158562701L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4858499365994228372L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4985388526247212215L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5427690752003907742L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8345770078729361410L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5282746325148266565L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5136835108294046406L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7638499126655098847L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4196803465763616779L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -210252616925803098L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 5408390997510554072L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -558574720700026552L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -5859602178330779818L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6030806797009414919L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -4879440063275753876L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7544785692657587891L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7559037565658854262L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8176671561863922335L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8357706395007423635L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3891620263162042002L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4402979137200077571L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 6184713140914290692L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8833615709177362898L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8966464019536083462L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 884344361116801768L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4705266176965428530L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7933481855003762391L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6767911387966177009L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -3990557132708298675L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -6809730074072730564L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7870338846549177528L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 3501835402182058104L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 7528375525065502317L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 8127383949220762034L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -7149672510980652364L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4061029732997495396L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, -8811357979219904563L });

            migrationBuilder.InsertData(
                table: "DockingDomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { 2, 4681360241400536090L });

            migrationBuilder.CreateIndex(
                name: "IX_DockingDomainProtein_ProteinId",
                table: "DockingDomainProtein",
                column: "ProteinId");

            migrationBuilder.CreateIndex(
                name: "IX_DockingProteins_ApprovedSymbol",
                table: "DockingProteins",
                column: "ApprovedSymbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DockingResults_ProteinId",
                table: "DockingResults",
                column: "ProteinId");

            migrationBuilder.CreateIndex(
                name: "IX_DockingTaskDomain_DomainId",
                table: "DockingTaskDomain",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_DockingTaskLigand_LigandId",
                table: "DockingTaskLigand",
                column: "LigandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new NotSupportedException("Should not rollback to the previous migration.");
        }
    }
}
