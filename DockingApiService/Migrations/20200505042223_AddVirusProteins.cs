using Microsoft.EntityFrameworkCore.Migrations;

namespace DockingApiService.Migrations
{
    public partial class AddVirusProteins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4058645023288619707L,
                columns: new[] { "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 3, "[false,false,false]", "[1,1,1]", 637240013558480593L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -3067408533286098795L, "orthosteric", 637239667169489020L, "ACE2_HUMAN", 1, "[true]", "[1]", 637239971779338384L });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "ACE2_HUMAN" });

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb",
                columns: new[] { "Description", "ProteinCount" },
                values: new object[] { "Virus-CKB is a knowledgebase for COVID-19 and similar viral infection research that implemented with our established chemogenomics tools as well as our algorithms for data visualization and analyses. This tool predicts the BioActivities on 92 viral related targets for a query compound and provides a handy user interface for viewing, downloading and plotting the output results.<br/><img class=\"w-50\" src=\"images/w01.jpg\"><img class=\"w-50\" src=\"images/w02.jpg\"><video class=\"w-100\" controls autoplay><source src=\"images/w03.mp4\" /></video>", 107 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACE2_HUMAN",
                columns: new[] { "DomainCount", "StructureCount" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_SARS2",
                column: "StructureCount",
                value: 3);

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "MTASE_SARS2", 637239666180705527L, 1, "MTASE", false, false, false, "", "SARS2", "", "MTASE", 2, 637239668458255002L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NSP15_SARS2", 637239666181235587L, 1, "NSP15", false, false, false, "", "SARS2", "", "NSP15", 1, 637239668478900945L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "NSP3_SARS2", 637239666180825498L, 1, "NSP3", false, false, false, "", "SARS2", "", "NSP3", 1, 637239668462005882L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "PLP_SARS2", 637239666180945508L, 1, "PLP", false, false, false, "", "SARS2", "", "PLP", 1, 637239668467030350L });

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "StructureCount", "Updated" },
                values: new object[] { "RDRP_SARS2", 637239666181075709L, 1, "RDRP", true, true, false, "", "SARS2", "", "RDRP", 1, 637239668473105626L });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4058645023288619707L, 1, 637239666181505614L, false, 1, 188049099990168071L, null, 637239668488928908L, "6M0J" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4058645023288619707L, 2, 637239666181415550L, false, 1, -6765995479237674581L, null, 637239668484688897L, "6LZG" });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 7851198700861725024L, "orthosteric", 637239666180815682L, "NSP3_SARS2", 1, "[true]", "[1]", 637239972210604911L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -8516103848431608519L, "orthosteric", 637239666180645610L, "MTASE_SARS2", 1, "[false]", "[1]", 637239972000268837L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 6169493773543630614L, "orthosteric2", 637239963392769807L, "MTASE_SARS2", 1, "[true]", "[1]", 637239972086908884L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 7647494603071938670L, "orthosteric", 637239666181055526L, "RDRP_SARS2", 1, "[true]", "[1]", 637239972380910789L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 548581059763981191L, "orthosteric", 637239666181215623L, "NSP15_SARS2", 1, "[true]", "[1]", 637239972261554116L });

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { -4011393937323257249L, "orthosteric", 637239666180935847L, "PLP_SARS2", 1, "[true]", "[1]", 637239972331346561L });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "MTASE_SARS2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NSP15_SARS2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "RDRP_SARS2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "NSP3_SARS2" });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[] { "virus-ckb", "PLP_SARS2" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms" },
                values: new object[] { "PLP_SARS2", "", "", "", "[]" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms" },
                values: new object[] { "RDRP_SARS2", "", "", "", "[]" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms" },
                values: new object[] { "NSP15_SARS2", "", "", "", "[]" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms" },
                values: new object[] { "MTASE_SARS2", "", "", "", "[]" });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms" },
                values: new object[] { "NSP3_SARS2", "", "", "", "[]" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -3067408533286098795L, 0, 637239668454015875L, true, 1, -8152240725450934079L, null, 637239668454015875L, "1R4L" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -8516103848431608519L, 0, 637239666180765520L, false, 1, 4333567916981903993L, null, 637239668458284416L, "6W61" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 6169493773543630614L, 0, 637239964643466102L, true, 1, 4333567916981903993L, null, 637239668458284416L, "6W61" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 548581059763981191L, 0, 637239666181285557L, true, 1, -3439687348433870217L, null, 637239668478920966L, "6W01" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7851198700861725024L, 0, 637239666180895634L, true, 1, -3328441069235444387L, null, 637239668462025873L, "6W6Y" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { -4011393937323257249L, 0, 637239666181005565L, true, 1, -7570172665211136343L, null, 637239668467050414L, "6W9C" });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated", "Pdb_Id" },
                values: new object[] { 7647494603071938670L, 0, 637239666181155524L, true, 1, -4141511152179139705L, null, 637239668473125591L, "7BV2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "ACE2_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "MTASE_SARS2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NSP15_SARS2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "NSP3_SARS2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "PLP_SARS2" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "virus-ckb", "RDRP_SARS2" });

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "MTASE_SARS2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NSP15_SARS2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NSP3_SARS2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "PLP_SARS2");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "RDRP_SARS2");

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -8516103848431608519L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4058645023288619707L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4058645023288619707L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -4011393937323257249L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3067408533286098795L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 548581059763981191L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 6169493773543630614L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7647494603071938670L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 7851198700861725024L, 0 });

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -8516103848431608519L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4011393937323257249L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3067408533286098795L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 548581059763981191L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 6169493773543630614L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 7647494603071938670L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 7851198700861725024L);

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MTASE_SARS2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP15_SARS2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NSP3_SARS2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "PLP_SARS2");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "RDRP_SARS2");

            migrationBuilder.UpdateData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -4058645023288619707L,
                columns: new[] { "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[] { 1, "[false]", "[1]", 637196402464806682L });

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb",
                columns: new[] { "Description", "ProteinCount" },
                values: new object[] { "Viral-CKB is a knowledgebase for COVID-19 and similar viral infection research that implemented with our established chemogenomics tools as well as our algorithms for data visualization and analyses. This tool predicts the BioActivities on 92 viral related targets for a query compound and provides a handy user interface for viewing, downloading and plotting the output results.<br/><img class=\"w-50\" src=\"images/w01.jpg\"><img class=\"w-50\" src=\"images/w02.jpg\"><video class=\"w-100\" controls autoplay><source src=\"images/w03.mp4\" /></video>", 101 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACE2_HUMAN",
                columns: new[] { "DomainCount", "StructureCount" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SPIKE_SARS2",
                column: "StructureCount",
                value: 1);
        }
    }
}
