using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DockingApiService.Migrations
{
    public partial class AddPCDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -5783944954983295385L,
                columns: new[] { "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 3, "[true,true,true]", "[1,1,1]", 637794444764302125L });

            migrationBuilder.UpdateData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4981783059841300572L,
                columns: new[] { "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2, "[true,true]", "[1,1]", 637794444762581823L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -8871046110588569328L, "orthosteric", 637793977402426008L, "HXK4_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978450753012L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -7140347544931996668L, "orthosteric", 637793977397652514L, "PGDH_HUMAN", 1, "[true]", "[1]", 637793978608432814L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -7075443287194353415L, "orthosteric", 637793977395186300L, "PA2GA_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978566242535L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6905197474869230509L, "orthosteric", 637793977407965440L, "CDK6_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978279299426L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -5892282866633928296L, "orthosteric", 637793977385301898L, "MK13_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978542591033L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -4969653094761442318L, "orthosteric", 637793977403848065L, "PK3CA_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978645357621L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -3731016000902705883L, "orthosteric", 637793977393793728L, "CP2C8_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978334180651L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -2715630506850651739L, "orthosteric", 637793977385887799L, "PDPK1_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978602481554L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -2470593977964099048L, "orthosteric", 637793977399591553L, "VGFR1_HUMAN", 2, "[true,true]", "[1,1]", 637793978776958069L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -785828524430232047L, "orthosteric", 637793977390080560L, "CDK1_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978261370839L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 1125439128633235237L, "orthosteric", 637793977398214299L, "KPCA_HUMAN", 2, "[true,true]", "[1,1]", 637793978482028196L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 3567290797582709467L, "orthosteric", 637793977391219132L, "CSF1R_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978352391071L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 7078911495602395233L, "orthosteric", 637793977389583800L, "KPCB_HUMAN", 1, "[true]", "[1]", 637793978488058387L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 7475026234373613481L, "orthosteric", 637793977387046769L, "CHK2_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978298252862L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 8859541809203396514L, "orthosteric", 637793977394443875L, "CP2A6_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978316470244L });

            migrationBuilder.InsertData(
                table: "Domains",
                columns: new[] { "Id", "Citation", "Created", "Description", "IsPublic", "Keywords", "Name", "ProteinCount", "Updated" },
                values: new object[] { "pcdb", "", 637793568000000000L, "PCDB is a knowledgebase for pancreatic cancer related protein targets which has been implemented with our established set of chemogenomics tools including MCCS, HTDocking, TargetHunter, BBB predictor and spider plot. PCDB contains 44 proteins associated with pancreatic cancer pathology which can be screened for hits against query compounds.", true, "[\"PancreaticDB\",\"Pancreatic Cancer\",\"PCDB\",\"Knowledgabase\",\"Computational Systems Pahrmacology\",\"Drug Repurposing\",\"Drug Combination\"]", "Pancreatic Cancer Chemogenomics Knowledgebase", 40, 0L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AMPN_HUMAN",
                columns: new[] { "Created", "DomainCount", "Updated" },
                values: new object[] { 637793977882669521L, 3, 637793977882669521L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK1_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977925866736L, 2, 3, 637793977925866736L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK6_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793978002699488L, 2, 3, 637793978002699488L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CHK2_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977919552458L, 2, 3, 637793977919552458L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2A6_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793978045824218L, 2, 3, 637793978045824218L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2C8_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793978028995339L, 2, 3, 637793978029005425L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CSF1R_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793978035404698L, 2, 3, 637793978035404698L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HXK4_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977901239469L, 2, 3, 637793977901249454L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCA_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793978017876041L, 3, 2, 637793978017876041L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCB_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977891810940L, 2, 1, 637793977891810940L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK13_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977880633398L, 2, 3, 637793977880633398L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NPY1R_HUMAN",
                columns: new[] { "Created", "DomainCount", "Updated" },
                values: new object[] { 637793977972079733L, 3, 637793977972079733L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PA2GA_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977896455319L, 2, 3, 637793977896455319L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDPK1_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977927729301L, 2, 3, 637793977927738842L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PGDH_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977978025341L, 2, 1, 637793977978025341L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PGH2_HUMAN",
                columns: new[] { "Created", "DomainCount", "Updated" },
                values: new object[] { 637793978056283805L, 4, 637793978056283805L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PK3CA_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977906914615L, 2, 3, 637793977906924908L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PPAP_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977893084678L, 2, 2, 637793977893084678L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TNFA_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977919552458L, 3, 3, 637793977919552458L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VGFR1_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637793977887537672L, 3, 2, 637793977887537672L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "ABCG2_HUMAN", 3716, 637793978024066289L, 1, "ABCG2", true, true, false, "Homo sapiens;Human", "HUMAN", "ATP binding cassette subfamily G member 2 (Junior blood group)", "ABCG2", 4023, 2, 637793978024066289L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "ACK1_HUMAN", 2712, 637793978046115611L, 1, "TNK2", true, true, false, "Homo sapiens;Human", "HUMAN", "tyrosine kinase non receptor 2", "ACK1", 2743, 3, 637793978046115611L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "ALDOA_HUMAN", 1, 637793977924223795L, 1, "ALDOA", false, false, false, "Homo sapiens;Human", "HUMAN", "aldolase, fructose-bisphosphate A", "ALDOA", 1, 1, 637793977924223795L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "AMYP_HUMAN", 65, 637793977905611639L, 1, "AMY2A", true, true, false, "Homo sapiens;Human", "HUMAN", "amylase alpha 2A", "AMYP", 74, 3, 637793977905611639L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "CATD_HUMAN", 2981, 637793977930333409L, 1, "CTSD", true, true, false, "Homo sapiens;Human", "HUMAN", "cathepsin D", "CATD", 3039, 3, 637793977930333409L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "F16P1_HUMAN", 771, 637793977915231651L, 1, "FBP1", true, true, false, "Homo sapiens;Human", "HUMAN", "fructose-bisphosphatase 1", "F16P1", 801, 3, 637793977915231651L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "FABP6_HUMAN", 45, 637793977879683415L, 1, "FABP6", true, true, false, "Homo sapiens;Human", "HUMAN", "fatty acid binding protein 6", "FABP6", 45, 1, 637793977879693494L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "FGFR3_HUMAN", 5580, 637793977925614085L, 1, "FGFR3", true, true, false, "Homo sapiens;Human", "HUMAN", "fibroblast growth factor receptor 3", "FGFR3", 5643, 2, 637793977925624078L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "GSK3B_HUMAN", 8685, 637793978133556244L, 1, "GSK3B", true, true, false, "Homo sapiens;Human", "HUMAN", "glycogen synthase kinase 3 beta", "GSK3B", 8919, 3, 637793978133566222L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "HDAC4_HUMAN", 1780, 637793977897786851L, 1, "HDAC4", true, true, false, "Homo sapiens;Human", "HUMAN", "histone deacetylase 4", "HDAC4", 1842, 3, 637793977897786851L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "HEXB_HUMAN", 127, 637793977938200433L, 1, "HEXB", true, true, false, "Homo sapiens;Human", "HUMAN", "hexosaminidase subunit beta", "HEXB", 130, 2, 637793977938474646L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "KAPCA_HUMAN", 3326, 637793977886223957L, 1, "PRKACA", true, true, false, "Homo sapiens;Human", "HUMAN", "protein kinase cAMP-activated catalytic subunit alpha", "KAPCA", 3333, 3, 637793977886233966L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "KPCI_HUMAN", 2797, 637793977900126574L, 1, "PRKCI", true, true, false, "Homo sapiens;Human", "HUMAN", "protein kinase C iota", "KPCI", 2798, 3, 637793977900136703L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "M3K20_HUMAN", 1268, 637793977915221670L, 1, "MAP3K20", true, true, false, "Homo sapiens;Human", "HUMAN", "mitogen-activated protein kinase kinase kinase 20", "M3K20", 1271, 3, 637793977915221670L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "PAK1_HUMAN", 2324, 637793977956855901L, 1, "PAK1", true, true, false, "Homo sapiens;Human", "HUMAN", "p21 (RAC1) activated kinase 1", "PAK1", 2365, 3, 637793977956855901L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "PTK6_HUMAN", 2476, 637793977902632684L, 1, "PTK6", true, true, false, "Homo sapiens;Human", "HUMAN", "protein tyrosine kinase 6", "PTK6", 2547, 3, 637793977902642668L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "S10A9_HUMAN", 61, 637793978009110167L, 1, "S100A9", true, true, false, "Homo sapiens;Human", "HUMAN", "S100 calcium binding protein A9", "S10A9", 61, 1, 637793978009110167L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "ST14_HUMAN", 579, 637793978034038735L, 1, "ST14", true, true, false, "Homo sapiens;Human", "HUMAN", "ST14 transmembrane serine protease matriptase", "ST14", 597, 3, 637793978034048715L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "ST1A1_HUMAN", 79, 637793978154561831L, 1, "SULT1A1", true, true, false, "Homo sapiens;Human", "HUMAN", "sulfotransferase family 1A member 1", "ST1A1", 111, 2, 637793978154571857L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[] { "XIAP_HUMAN", 3584, 637793977897786851L, 1, "XIAP", true, true, false, "Homo sapiens;Human", "HUMAN", "X-linked inhibitor of apoptosis", "XIAP", 3635, 3, 637793977897786851L });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5783944954983295385L, 1, 637793978755623622L, true, 1, -2071426260727561276L, -6506807998555480327L, 637793978755623622L, "4TWT" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5783944954983295385L, 2, 637793978766286374L, true, 1, -7122801637471786054L, -7122801637471786054L, 637793978766296423L, "6X81" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4981783059841300572L, 1, 637793978658440914L, true, 1, 1403325687760428010L, 1403325687760428010L, 637793978658440914L, "2HPA" });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -8171407003965529949L, "orthosteric", 637793977400219619L, "FGFR3_HUMAN", 2, "[true,true]", "[1,1]", 637793978388475800L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -8027862931554190776L, "orthosteric", 637793977406426648L, "HDAC4_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978422643891L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6956070581153719971L, "orthosteric", 637793977411856563L, "ST14_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978705150643L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -6094256293848835522L, "orthosteric", 637793977409269677L, "PAK1_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978582169443L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -5303400785705403560L, "orthosteric", 637793977405270692L, "ST1A1_HUMAN", 2, "[true,true]", "[1,1]", 637793978718208366L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -4934665461339377528L, "orthosteric", 637793977403201765L, "KPCI_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978506114960L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -4934339368451811946L, "orthosteric", 637793977393219241L, "F16P1_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978370364624L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -3876813666909213180L, "orthosteric", 637793977398746760L, "KAPCA_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978470234944L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -1994069720960317355L, "orthosteric", 637793977411232376L, "ABCG2_HUMAN", 2, "[true,true]", "[1,1]", 637793978168909852L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -1749548440946155297L, "orthosteric", 637793977409873052L, "PTK6_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978679904995L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -1449860211582487193L, "orthosteric", 637793977408694486L, "ACK1_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978189277205L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -234816316403957216L, "orthosteric", 637793977390766828L, "S10A9_HUMAN", 1, "[true]", "[1]", 637793978687418719L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -74247990317349547L, "orthosteric", 637793977388352103L, "ALDOA_HUMAN", 1, "[true]", "[1]", 637793978195565236L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2223118468879282905L, "orthosteric", 637793977388958468L, "AMYP_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978220459991L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2253599398961415171L, "orthosteric", 637793977392609466L, "HEXB_HUMAN", 2, "[true,true]", "[1,1]", 637793978432651180L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2655593343911301044L, "orthosteric", 637793977407110437L, "XIAP_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978795753258L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 2889134837062270531L, "orthosteric", 637793977391943553L, "CATD_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978239244330L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 3336420578020325841L, "orthosteric", 637793977404480880L, "GSK3B_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978404371017L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 4903655206353593413L, "orthosteric", 637793977410533655L, "M3K20_HUMAN", 3, "[true,true,true]", "[1,1,1]", 637793978524069059L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 6498145122170692348L, "orthosteric", 637793977405868615L, "FABP6_HUMAN", 1, "[true]", "[1]", 637793978376512862L });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "ABCG2_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "ACK1_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "ALDOA_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "AMPN_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "AMYP_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "CATD_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "CDK1_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "CDK6_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "CHK2_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "CP2A6_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "CP2C8_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "CSF1R_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "F16P1_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "FABP6_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "FGFR3_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "GSK3B_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "HDAC4_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "HEXB_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "HXK4_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "KAPCA_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "KPCA_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "KPCB_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "KPCI_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "M3K20_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "MK13_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "NPY1R_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "PA2GA_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "PAK1_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "PDPK1_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "PGDH_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "PGH2_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "PK3CA_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "PPAP_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "PTK6_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "S10A9_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "ST14_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "ST1A1_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "TNFA_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "VGFR1_HUMAN" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "pcdb", "XIAP_HUMAN" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "ABCG2_HUMAN", "4q22.1", "ATP binding cassette subfamily G;Blood group antigens;CD molecules", "gene with protein product", "[]", "CHEMBL5393", "ENSG00000118777", "AF103796", 74, "NM_004827", "Q9UNQ0" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "ACK1_HUMAN", "3q29", "TNK family tyrosine kinases;MicroRNA protein coding host genes", "gene with protein product", "[\"activated Cdc42-associated kinase 1\"]", "CHEMBL4599", "ENSG00000061938", "L13738", 19297, "NM_005781", "Q07912" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "ALDOA_HUMAN", "16p11.2", "Aldolases", "gene with protein product", "[]", "CHEMBL2106", "ENSG00000149925", "X05236", 414, "NM_000034", "P04075" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "AMYP_HUMAN", "1p21.1", "Amylases alpha", "gene with protein product", "[]", "CHEMBL2045", "ENSG00000243480", "BC007060", 477, "NM_000699", "P04746" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "CATD_HUMAN", "11p15.5", "Cathepsins;Peptidase family A1", "gene with protein product", "[\"ceroid-lipofuscinosis\",\"neuronal 10\"]", "CHEMBL2581", "ENSG00000117984", "M11233", 2529, "NM_001909", "P07339" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "F16P1_HUMAN", "9q22.32", "Fructose-1,6-bisphosphatases", "gene with protein product", "[]", "CHEMBL3975", "ENSG00000165140", "M19922", 3606, "NM_000507", "P09467" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "FABP6_HUMAN", "5q33.3", "Fatty acid binding protein family", "gene with protein product", "[\"illeal lipid-binding protein;ileal bile acid binding protein;gastrotropin\"]", "CHEMBL4523235", "ENSG00000170231", "U19869", 3561, "NM_001040442", "P51161" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "FGFR3_HUMAN", "4p16.3", "I-set domain containing;Receptor tyrosine kinases;CD molecules", "gene with protein product", "[]", "CHEMBL2742", "ENSG00000068078", "M64347", 3690, "NM_000142", "P22607" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "GSK3B_HUMAN", "3q13.33", "", "gene with protein product", "[]", "CHEMBL262", "ENSG00000082701", "BC012760", 4617, "NM_001146156", "P49841" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "HDAC4_HUMAN", "2q37.3", "Histone deacetylases, class IIA;MicroRNA protein coding host genes", "gene with protein product", "[]", "CHEMBL3524", "ENSG00000068024", "AB006626", 14063, "NM_006037", "P56524" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "HEXB_HUMAN", "5q13.3", "Hexosaminidases", "gene with protein product", "[\"beta-hexosaminidase subunit beta\"]", "CHEMBL5877", "ENSG00000049860", "M13519", 4879, "NM_000521", "P07686" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "KAPCA_HUMAN", "19p13.12", "AGC family kinases", "gene with protein product", "[]", "CHEMBL4101", "ENSG00000072062", 9380, "NM_002730", "P17612" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "KPCI_HUMAN", "3q26.2", "AGC family kinases", "gene with protein product", "[]", "CHEMBL2598", "ENSG00000163558", 9404, "NM_002740", "P41743" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "M3K20_HUMAN", "2q31.1", "Mitogen-activated protein kinase kinase kinases", "gene with protein product", "[\"ZAK1 homolog\",\"leucine zipper and sterile-alpha motif kinase (Dictyostelium);mixed lineage kinase 7\"]", "CHEMBL3886", "ENSG00000091436", "AB049733", 17797, "NM_016653", "Q9NYL2" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "PAK1_HUMAN", "11q13.5-q14.1", "", "gene with protein product", "[\"STE20 homolog\",\"yeast\"]", "CHEMBL4600", "ENSG00000149269", "U51120", 8590, "NM_002576", "Q13153" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "PTK6_HUMAN", "20q13.33", "PTK6 family tyrosine kinases;SH2 domain containing", "gene with protein product", "[]", "CHEMBL4601", "ENSG00000101213", "U61412", 9617, "NM_001256358", "Q13882" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "S10A9_HUMAN", "1q21.3", "S100 calcium binding proteins;EF-hand domain containing", "gene with protein product", "[\"Calprotectin L1H subunit;Leukocyte L1 complex heavy chain;Migration inhibitory factor-related protein 14\"]", "CHEMBL4296265", "ENSG00000163220", "BC047681", 10499, "NM_002965", "P06702" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "ST14_HUMAN", "11q24.3", "Type II transmembrane serine proteases", "gene with protein product", "[\"epithin;matriptase;channel–activating protein 3\"]", "CHEMBL3018", "ENSG00000149418", "AF118224", 11344, "NM_021978", "Q9Y5Y6" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "ST1A1_HUMAN", "16p11.2", "Sulfotransferases, cytosolic", "gene with protein product", "[]", "CHEMBL1743291", "ENSG00000196502", "U52852", 11453, "NM_001055", "P50225" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "UniProt_Id" },
                values: new object[] { "XIAP_HUMAN", "Xq25", "Baculoviral IAP repeat containing;Ring finger proteins", "gene with protein product", "[\"IAP-like protein 1\"]", "CHEMBL4198", "ENSG00000101966", "U45880", 592, "NM_001167", "P98170" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8871046110588569328L, 0, 637793978438510562L, true, 1, -5654806914066584652L, -5654806914066584652L, 637793978438510562L, "1V4S" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8871046110588569328L, 1, 637793978444865775L, true, 1, 8209696255104087204L, 8209696255104087204L, 637793978444875865L, "3A0I" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8871046110588569328L, 2, 637793978450702054L, true, 1, 2221839697463669560L, 2221839697463669560L, 637793978450702054L, "4RCH" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7140347544931996668L, 0, 637793978608412808L, true, 1, -8669255532624535681L, -8794686210916219472L, 637793978608412808L, "2GDZ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7075443287194353415L, 0, 637793978553995870L, true, 1, -9143199193379624700L, -9143199193379624700L, 637793978554005889L, "1DB5" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7075443287194353415L, 1, 637793978559431056L, true, 1, 64494053952184053L, 64494053952184053L, 637793978559441485L, "1DCY" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -7075443287194353415L, 2, 637793978566162635L, true, 1, -7731070815783135068L, -7700600164862830450L, 637793978566162635L, "1J1A" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6905197474869230509L, 0, 637793978268093237L, true, 1, -3634804655623033698L, -1641642298411059971L, 637793978268093237L, "2EUF" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6905197474869230509L, 1, 637793978273819860L, true, 1, -7967632868393145275L, 4252196581110908595L, 637793978273829857L, "2F2C" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6905197474869230509L, 2, 637793978279259318L, true, 1, 8098059352601713175L, 8498752524604429420L, 637793978279269346L, "5L2I" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5892282866633928296L, 0, 637793978530434389L, true, 1, -2966604368902744312L, -2966604368902744312L, 637793978530445064L, "4EYJ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5892282866633928296L, 1, 637793978536664493L, true, 1, -5679398209387824757L, -5679398209387824757L, 637793978536664493L, "4EYM" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5892282866633928296L, 2, 637793978542560998L, true, 1, -5248923740254392372L, -5248923740254392372L, 637793978542560998L, "5EKN" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4969653094761442318L, 0, 637793978633048985L, true, 1, -4579474748012026569L, -4579474748012026569L, 637793978633048985L, "3ZIM" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4969653094761442318L, 1, 637793978636676073L, true, 1, -7733546620732523388L, 3256857417063705705L, 637793978636676073L, "4ZOP" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4969653094761442318L, 2, 637793978645318204L, true, 1, -497613088787694717L, -497613088787694717L, 637793978645318204L, "5DXH" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3731016000902705883L, 0, 637793978322371266L, true, 1, -844512994986734178L, -844512994986734178L, 637793978322381312L, "2NNI" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3731016000902705883L, 1, 637793978328088612L, true, 1, 7038752978387320599L, 7038752978387320599L, 637793978328098004L, "2NNJ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3731016000902705883L, 2, 637793978334111012L, true, 1, 6866606529025896854L, 6866606529025896854L, 637793978334120327L, "2VN0" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2715630506850651739L, 0, 637793978590055386L, true, 1, 3320926821619968502L, -894146854133271609L, 637793978590065407L, "1OKZ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2715630506850651739L, 1, 637793978596134373L, true, 1, -6060094087793918404L, 8536746437842346078L, 637793978596143647L, "1UU7" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2715630506850651739L, 2, 637793978602451287L, true, 1, 8605508154516767360L, 8605508154516767360L, 637793978602451287L, "5HKM" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2470593977964099048L, 0, 637793978770552127L, true, 1, 4374236813344607726L, 193685791704601718L, 637793978770562063L, "3HNG" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -2470593977964099048L, 1, 637793978776928057L, true, 1, -4751640158832900224L, -4751640158832900224L, 637793978776938080L, "5EX3" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -785828524430232047L, 0, 637793978244860676L, true, 1, 8414105699682198070L, 8414105699682198070L, 637793978244870642L, "5HQ0" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -785828524430232047L, 1, 637793978254275000L, true, 1, 2937556686110116861L, -7706582918615613458L, 637793978254285089L, "6GU2" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -785828524430232047L, 2, 637793978261310343L, true, 1, 1816382262033008327L, 1816382262033008327L, 637793978261310343L, "6GU3" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1125439128633235237L, 0, 637793978476391409L, true, 1, -1090225434679658467L, -3742677810930146168L, 637793978476391409L, "3IW4" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 1125439128633235237L, 1, 637793978481968091L, true, 1, -8495806780890424769L, -4174270587797262816L, 637793978481968091L, "4RA4" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3567290797582709467L, 0, 637793978340388543L, true, 1, 7529353753569382099L, 7529353753569382099L, 637793978340398534L, "2I1M" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3567290797582709467L, 1, 637793978346538712L, true, 1, -7205390298791649134L, -7205390298791649134L, 637793978346548552L, "3BEA" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3567290797582709467L, 2, 637793978352370850L, true, 1, 7321853924725786812L, 7321853924725786812L, 637793978352370850L, "4HW7" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7078911495602395233L, 0, 637793978488038265L, true, 1, 712798789820489552L, 712798789820489552L, 637793978488038265L, "2I0E" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7475026234373613481L, 0, 637793978285379983L, true, 1, -2746403436236966919L, -2746403436236966919L, 637793978285390764L, "2CN8" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7475026234373613481L, 1, 637793978292237269L, true, 1, -7246922448554814821L, 8293432244598507132L, 637793978292247320L, "4A9U" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7475026234373613481L, 2, 637793978298232483L, true, 1, 4397634968480212883L, -1577199229057211031L, 637793978298232483L, "4BDA" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8859541809203396514L, 0, 637793978303855393L, true, 1, -1610570784001191588L, -1610570784001191588L, 637793978303855393L, "1Z10" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8859541809203396514L, 1, 637793978310372183L, true, 1, -8644449792416731251L, -8644449792416731251L, 637793978310372183L, "1Z11" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 8859541809203396514L, 2, 637793978316450072L, true, 1, -4661276254401319812L, -4661276254401319812L, 637793978316450072L, "2FDU" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8171407003965529949L, 0, 637793978382489763L, true, 1, -2322270291639592536L, 3680317773730583146L, 637793978382489763L, "6LVM" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8171407003965529949L, 1, 637793978388435582L, true, 1, 88209489298190914L, -9148702547957341046L, 637793978388445766L, "7DHL" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8027862931554190776L, 0, 637793978410184406L, true, 1, -2075512936531157094L, 3935375595241355041L, 637793978410194430L, "2VQM" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8027862931554190776L, 1, 637793978415895396L, true, 1, 5536037704415988286L, 6598779174599008491L, 637793978415905593L, "4CBT" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8027862931554190776L, 2, 637793978422603636L, true, 1, 8007942211698949885L, 3877765100658967160L, 637793978422614092L, "5A2S" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6956070581153719971L, 0, 637793978693158374L, true, 1, 7865845695084220677L, 7865845695084220677L, 637793978693158374L, "1EAX" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6956070581153719971L, 1, 637793978698793649L, true, 1, -703395690203759977L, -703395690203759977L, 637793978698803928L, "2GV6" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6956070581153719971L, 2, 637793978705070395L, true, 1, 1827636578780529561L, 3734485556854567471L, 637793978705080313L, "4JYT" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6094256293848835522L, 0, 637793978569887359L, true, 1, -7013734458496663232L, -7275369904906087816L, 637793978569887359L, "2HY8" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6094256293848835522L, 1, 637793978575905295L, true, 1, -5811969859320868414L, 4127238819233019997L, 637793978575915068L, "3FXZ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -6094256293848835522L, 2, 637793978582099252L, true, 1, -8404707467371392323L, 4996412759545158100L, 637793978582109239L, "4ZY4" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5303400785705403560L, 0, 637793978711529026L, true, 1, 6506332559801261124L, 1921695737663387039L, 637793978711537447L, "2D06" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -5303400785705403560L, 1, 637793978718178197L, true, 1, 8854463881936472626L, 8854463881936472626L, 637793978718188337L, "3U3M" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4934665461339377528L, 0, 637793978493595469L, true, 1, -7409167474930090472L, 4395617454860754224L, 637793978493595469L, "1ZRZ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4934665461339377528L, 1, 637793978500057426L, true, 1, 442877254630649081L, 4863580072064069916L, 637793978500067399L, "3ZH8" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4934665461339377528L, 2, 637793978506044868L, true, 1, -8681283338978804190L, 3797802233640678898L, 637793978506054815L, "6ILZ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4934339368451811946L, 0, 637793978358361291L, true, 1, 3455052410600920307L, 3455052410600920307L, 637793978358371305L, "2JJK" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4934339368451811946L, 1, 637793978364530852L, true, 1, 1027405289289151203L, 1027405289289151203L, 637793978364530852L, "2Y5K" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4934339368451811946L, 2, 637793978370344674L, true, 1, 6754833023741764624L, 6754833023741764624L, 637793978370344674L, "3A29" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3876813666909213180L, 0, 637793978456846799L, true, 1, -4097300467211065269L, 8550401649343785602L, 637793978456856828L, "2GU8" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3876813666909213180L, 1, 637793978463078053L, true, 1, -8548518076057861274L, -9087948307537446592L, 637793978463078053L, "4UJB" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3876813666909213180L, 2, 637793978470184373L, true, 1, -9038631392076042558L, 4550972034631322674L, 637793978470184373L, "5UZK" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1994069720960317355L, 0, 637793978162266187L, true, 1, 1688421804383743324L, 1688421804383743324L, 637793978162275759L, "6ETI" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1994069720960317355L, 1, 637793978168829744L, true, 1, 2276985808857513680L, 2276985808857513680L, 637793978168829744L, "6HCO" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1749548440946155297L, 0, 637793978664184796L, true, 1, -8841673153466186671L, 2198544439476324907L, 637793978664184796L, "5DA3" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1749548440946155297L, 1, 637793978672631640L, true, 1, -3390821649492259818L, 6042764225100733278L, 637793978672641140L, "5H2U" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1749548440946155297L, 2, 637793978679864945L, true, 1, -5412593746554471793L, -5412593746554471793L, 637793978679864945L, "6CZ3" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1449860211582487193L, 0, 637793978175195488L, true, 1, 4092812970677065047L, 4092812970677065047L, 637793978175205468L, "3EQR" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1449860211582487193L, 1, 637793978181667158L, true, 1, 8156970937124539594L, 8156970937124539594L, 637793978181676555L, "4EWH" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -1449860211582487193L, 2, 637793978189217131L, true, 1, 8542099262350868418L, 8542099262350868418L, 637793978189227205L, "4ID7" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -234816316403957216L, 0, 637793978687398640L, true, 1, -3105625521546024447L, -3105625521546024447L, 637793978687398640L, "1IRJ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -74247990317349547L, 0, 637793978195525116L, true, 1, 4889871231493382770L, 4889871231493382770L, 637793978195525116L, "4ALD" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2223118468879282905L, 0, 637793978208655745L, true, 1, 7849650141550622648L, 7849650141550622648L, 637793978208655745L, "1U2Y" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2223118468879282905L, 1, 637793978214257163L, true, 1, 1246689754332438061L, 1246689754332438061L, 637793978214267579L, "1XD0" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2223118468879282905L, 2, 637793978220409906L, true, 1, -6083218970547114939L, -6083218970547114939L, 637793978220409906L, "6OCN" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2253599398961415171L, 0, 637793978428587928L, true, 1, 7425920420776400429L, 7425920420776400429L, 637793978428587928L, "1NOW" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2253599398961415171L, 1, 637793978432600986L, true, 1, -1107137421223501542L, -1107137421223501542L, 637793978432610949L, "3LMY" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2655593343911301044L, 0, 637793978783625057L, true, 1, -5814048130297501458L, -5814048130297501458L, 637793978783625057L, "2JK7" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2655593343911301044L, 1, 637793978789475416L, true, 1, 9135747398626817962L, 9135747398626817962L, 637793978789475416L, "5M6M" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2655593343911301044L, 2, 637793978795693242L, true, 1, -1240879752416774556L, -1240879752416774556L, 637793978795703234L, "5OQW" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2889134837062270531L, 0, 637793978226411916L, true, 1, 1852092346125575248L, 1852092346125575248L, 637793978226411916L, "4OBZ" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2889134837062270531L, 1, 637793978232627082L, true, 1, -5048032453148982103L, -5048032453148982103L, 637793978232636464L, "4OC6" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 2889134837062270531L, 2, 637793978239194219L, true, 1, -8761086215175355015L, -8761086215175355015L, 637793978239194219L, "4OD9" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3336420578020325841L, 0, 637793978394359419L, true, 1, -5018273942736158881L, -5018273942736158881L, 637793978394359419L, "1J1B" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3336420578020325841L, 1, 637793978400891391L, true, 1, 7796532882422363987L, -9028461927510149651L, 637793978400901503L, "2O5K" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 3336420578020325841L, 2, 637793978404290471L, true, 1, -5247644147613598558L, -5247644147613598558L, 637793978404301346L, "4DIT" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4903655206353593413L, 0, 637793978512529086L, true, 1, 4435184567596880226L, 4288902119777240404L, 637793978512538762L, "5HES" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4903655206353593413L, 1, 637793978518231405L, true, 1, 3332176386563093210L, 6813072413614072416L, 637793978518241588L, "5X5O" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 4903655206353593413L, 2, 637793978524018895L, true, 1, 4771017231100989427L, -3872414602845800444L, 637793978524018895L, "6JUT" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 6498145122170692348L, 0, 637793978376472745L, true, 1, 5139890718881082951L, -4840330105194961735L, 637793978376472745L, "5L8N" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "ABCG2_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "ACK1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "ALDOA_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "AMPN_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "AMYP_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "CATD_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "CDK1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "CDK6_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "CHK2_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "CP2A6_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "CP2C8_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "CSF1R_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "F16P1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "FABP6_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "FGFR3_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "GSK3B_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "HDAC4_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "HEXB_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "HXK4_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "KAPCA_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "KPCA_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "KPCB_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "KPCI_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "M3K20_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "MK13_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "NPY1R_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "PA2GA_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "PAK1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "PDPK1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "PGDH_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "PGH2_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "PK3CA_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "PPAP_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "PTK6_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "S10A9_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "ST14_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "ST1A1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "TNFA_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "VGFR1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "pcdb", "XIAP_HUMAN" });

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "ABCG2_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "ACK1_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "ALDOA_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "AMYP_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "CATD_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "F16P1_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "FABP6_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "FGFR3_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "GSK3B_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HDAC4_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "HEXB_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "KAPCA_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "KPCI_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "M3K20_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PAK1_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PTK6_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "S10A9_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "ST14_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "ST1A1_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "XIAP_HUMAN");

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8871046110588569328L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8871046110588569328L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8871046110588569328L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8171407003965529949L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8171407003965529949L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8027862931554190776L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8027862931554190776L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8027862931554190776L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7140347544931996668L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7075443287194353415L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7075443287194353415L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -7075443287194353415L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6956070581153719971L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6956070581153719971L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6956070581153719971L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6905197474869230509L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6905197474869230509L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6905197474869230509L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6094256293848835522L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6094256293848835522L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -6094256293848835522L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5892282866633928296L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5892282866633928296L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5892282866633928296L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5783944954983295385L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5783944954983295385L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5303400785705403560L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -5303400785705403560L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4981783059841300572L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4969653094761442318L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4969653094761442318L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4969653094761442318L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4934665461339377528L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4934665461339377528L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4934665461339377528L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4934339368451811946L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4934339368451811946L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4934339368451811946L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3876813666909213180L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3876813666909213180L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3876813666909213180L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3731016000902705883L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3731016000902705883L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3731016000902705883L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2715630506850651739L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2715630506850651739L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2715630506850651739L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2470593977964099048L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -2470593977964099048L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1994069720960317355L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1994069720960317355L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1749548440946155297L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1749548440946155297L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1749548440946155297L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1449860211582487193L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1449860211582487193L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -1449860211582487193L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -785828524430232047L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -785828524430232047L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -785828524430232047L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -234816316403957216L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -74247990317349547L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1125439128633235237L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 1125439128633235237L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2223118468879282905L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2223118468879282905L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2223118468879282905L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2253599398961415171L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2253599398961415171L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2655593343911301044L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2655593343911301044L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2655593343911301044L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2889134837062270531L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2889134837062270531L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 2889134837062270531L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3336420578020325841L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3336420578020325841L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3336420578020325841L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3567290797582709467L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3567290797582709467L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 3567290797582709467L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4903655206353593413L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4903655206353593413L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 4903655206353593413L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 6498145122170692348L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7078911495602395233L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7475026234373613481L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7475026234373613481L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7475026234373613481L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8859541809203396514L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8859541809203396514L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 8859541809203396514L, 2 });

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -8871046110588569328L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -8171407003965529949L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -8027862931554190776L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -7140347544931996668L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -7075443287194353415L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6956070581153719971L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6905197474869230509L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -6094256293848835522L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -5892282866633928296L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -5303400785705403560L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4969653094761442318L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4934665461339377528L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4934339368451811946L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3876813666909213180L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3731016000902705883L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -2715630506850651739L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -2470593977964099048L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -1994069720960317355L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -1749548440946155297L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -1449860211582487193L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -785828524430232047L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -234816316403957216L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -74247990317349547L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 1125439128633235237L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2223118468879282905L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2253599398961415171L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2655593343911301044L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 2889134837062270531L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 3336420578020325841L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 3567290797582709467L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 4903655206353593413L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 6498145122170692348L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 7078911495602395233L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 7475026234373613481L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 8859541809203396514L);

            migrationBuilder.DeleteData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "pcdb");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ABCG2_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACK1_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ALDOA_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AMYP_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CATD_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "F16P1_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FABP6_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FGFR3_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GSK3B_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HDAC4_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HEXB_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KAPCA_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCI_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "M3K20_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PAK1_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PTK6_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "S10A9_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ST14_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ST1A1_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "XIAP_HUMAN");

            migrationBuilder.UpdateData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -5783944954983295385L,
                columns: new[] { "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 1, "[true]", "[1]", 637147073038549419L });

            migrationBuilder.UpdateData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4981783059841300572L,
                columns: new[] { "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 1, "[true]", "[1]", 637147073030621166L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AMPN_HUMAN",
                columns: new[] { "Created", "DomainCount", "Updated" },
                values: new object[] { 637751446938959234L, 2, 637751446938959234L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK1_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447087899128L, 1, 0, 637751447087899128L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CDK6_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447308529113L, 1, 0, 637751447308529113L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CHK2_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447519096598L, 1, 0, 637751447519096598L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2A6_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447497789136L, 1, 0, 637751447497789136L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP2C8_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447535503093L, 1, 0, 637751447535503093L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CSF1R_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751446580427241L, 1, 0, 637751446580427241L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "HXK4_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447446953733L, 1, 0, 637751447446953733L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCA_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751446918021695L, 2, 0, 637751446918021695L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KPCB_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751446995584965L, 1, 0, 637751446995584965L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MK13_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447378915162L, 1, 0, 637751447378915162L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NPY1R_HUMAN",
                columns: new[] { "Created", "DomainCount", "Updated" },
                values: new object[] { 637751447198963246L, 2, 637751447198963246L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PA2GA_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751446569489580L, 1, 0, 637751446569489580L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PDPK1_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751446833346013L, 1, 0, 637751446833346013L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PGDH_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447102117785L, 1, 0, 637751447102117785L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PGH2_HUMAN",
                columns: new[] { "Created", "DomainCount", "Updated" },
                values: new object[] { 637751447000897235L, 3, 637751447000897235L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PK3CA_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447037989983L, 1, 0, 637751447037989983L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PPAP_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447432889410L, 1, 1, 637751447432889410L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TNFA_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447583550917L, 2, 1, 637751447583550917L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "VGFR1_HUMAN",
                columns: new[] { "Created", "DomainCount", "StructureCount", "Updated" },
                values: new object[] { 637751447489194553L, 2, 0, 637751447489194553L });
        }
    }
}
