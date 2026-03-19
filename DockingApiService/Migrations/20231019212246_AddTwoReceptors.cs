using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DockingApiService.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoReceptors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "depressionkb",
                column: "ProteinCount",
                value: 28);

            migrationBuilder.InsertData(
                table: "Proteins",
                columns: new[] { "Id", "BioactivityCount", "Created", "DomainCount", "GeneSymbol", "HasActiveChemblCompounds", "HasChemblCompounds", "HasTrainedModels", "Organism", "OrganismSymbol", "ProteinName", "ProteinSymbol", "RawBioactivityCount", "StructureCount", "Updated" },
                values: new object[,]
                {
                    { "NLRP3_HUMAN", 807, 638333437256389603L, 1, "NLRP3", true, true, false, "Homo sapiens;Human", "HUMAN", "NLR family pyrin domain containing 3", "NLRP3", 902, 3, 638333437256389603L },
                    { "P2RX7_HUMAN", 5403, 638333437256389603L, 1, "P2RX7", true, true, false, "Homo sapiens;Human", "HUMAN", "purinergic receptor P2X 7", "P2RX7", 5533, 3, 638333437256389603L }
                });

            migrationBuilder.UpdateData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -84197494709629435L, 1 },
                column: "PdbqtHash",
                value: 3237439704953008554L);

            migrationBuilder.UpdateData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -84197494709629435L, 2 },
                column: "PdbqtHash",
                value: 3237439704953008554L);

            migrationBuilder.InsertData(
                table: "Cavities",
                columns: new[] { "Id", "BindingSite", "Created", "ProteinId", "StructureCount", "StructureHasBindingLigands", "StructureObtainingMethods", "Updated" },
                values: new object[,]
                {
                    { -3425052966887734128L, "orthosteric", 638333449581839254L, "P2RX7_HUMAN", 3, "[true,true,true]", "[0,0,0]", 638333449665724277L },
                    { 5678928133094624970L, "orthosteric", 638333437257175023L, "NLRP3_HUMAN", 3, "[true,true,true]", "[1,1,1]", 638333437282636043L }
                });

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[,]
                {
                    { "depressionkb", "NLRP3_HUMAN" },
                    { "depressionkb", "P2RX7_HUMAN" }
                });

            migrationBuilder.InsertData(
                table: "ProteinProperties",
                columns: new[] { "ProteinId", "Chembl_Id", "Ensembl_Id", "GenBank_Id", "Hgnc_Id", "Ncbi_Id", "ChromosomalLocation", "GeneFamily", "LocusType", "Synonyms", "UniProt_Id" },
                values: new object[,]
                {
                    { "NLRP3_HUMAN", "CHEMBL1741208", "ENSG00000162711", "AF054176", 16400, "NM_004895", "1q44", "NLR family;Pyrin domain containing", "gene with protein product", "[\"Cryopyrin;nucleotide-binding oligomerization domain\",\"leucine rich repeat and pyrin domain containing 3\"]", "Q96P20" },
                    { "P2RX7_HUMAN", "CHEMBL4805", "ENSG00000089041", "Y09561", 8537, "NM_002562", "12q24.31", "Purinergic receptors P2X", "gene with protein product", "[]", "Q99572" }
                });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated" },
                values: new object[,]
                {
                    { -3425052966887734128L, 0, 638333438491009191L, true, 0, -6653274244579234594L, null, 638333437961845774L },
                    { -3425052966887734128L, 1, 638333438041742130L, true, 0, -7665190251177563255L, null, 638333437961845774L },
                    { -3425052966887734128L, 2, 638333437672523957L, true, 0, 8894212532306186870L, null, 638333437961845774L }
                });

            migrationBuilder.InsertData(
                table: "Structures",
                columns: new[] { "CavityId", "Index", "Pdb_Id", "Created", "HasBindingLigand", "ObtainingMethod", "PdbqtFixedHash", "PdbqtHash", "Updated" },
                values: new object[,]
                {
                    { 5678928133094624970L, 0, "7ALV", 638333437272267998L, true, 1, 8565534316674795715L, null, 638333437272267998L },
                    { 5678928133094624970L, 1, "7VTP", 638333437277914702L, true, 1, 7223194318906510770L, null, 638333437277914702L },
                    { 5678928133094624970L, 2, "8ETR", 638333437282636043L, true, 1, 1493501539112073014L, null, 638333437282636043L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "NLRP3_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "P2RX7_HUMAN" });

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "NLRP3_HUMAN");

            migrationBuilder.DeleteData(
                table: "ProteinProperties",
                keyColumn: "ProteinId",
                keyValue: "P2RX7_HUMAN");

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3425052966887734128L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3425052966887734128L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -3425052966887734128L, 2 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5678928133094624970L, 0 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5678928133094624970L, 1 });

            migrationBuilder.DeleteData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { 5678928133094624970L, 2 });

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: -3425052966887734128L);

            migrationBuilder.DeleteData(
                table: "Cavities",
                keyColumn: "Id",
                keyValue: 5678928133094624970L);

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NLRP3_HUMAN");

            migrationBuilder.DeleteData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "P2RX7_HUMAN");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "depressionkb",
                column: "ProteinCount",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -84197494709629435L, 1 },
                column: "PdbqtHash",
                value: null);

            migrationBuilder.UpdateData(
                table: "Structures",
                keyColumns: new[] { "CavityId", "Index" },
                keyValues: new object[] { -84197494709629435L, 2 },
                column: "PdbqtHash",
                value: null);
        }
    }
}
