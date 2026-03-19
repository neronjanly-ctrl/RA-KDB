using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DockingApiService.Migrations
{
    /// <inheritdoc />
    public partial class AddDepressionKB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Domains",
                columns: new[] { "Id", "Citation", "Created", "Description", "IsPublic", "Keywords", "Name", "ProteinCount", "Updated" },
                values: new object[] { "depressionkb", "", 638324928000000000L, "DepressionKB 1.0 is an advanced knowledgebase specifically designed for anti-depression research. It utilizes reported cutting-edge algorithms and tools to streamline data visualization and analysis. The platform accurately predicts BioActivities for designated anti-depression targets based on any given query compound. With a user-friendly interface, DepressionKB 1.0 makes tasks such as viewing, downloading, and plotting results straightforward. Our aim with this resource is to accelerate target identification and drug development, contributing to the discovery of effective anti-depression therapeutics.", true, "[\"DepressionKB\",\"Depression\",\"Knowledgabase\",\"Computational Systems Pahrmacology\",\"Drug Repurposing\",\"Drug Combination\"]", "Depression Chemogenomics Knowledgebase", 26, 0L });

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT1A_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT2A_HUMAN",
                column: "DomainCount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT4R_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT6R_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHB2_HUMAN",
                column: "DomainCount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACM1_HUMAN",
                column: "DomainCount",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACM4_HUMAN",
                column: "DomainCount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AOFA_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AOFB_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CNR2_HUMAN",
                column: "DomainCount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP46A_HUMAN",
                column: "DomainCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FKBP5_HUMAN",
                column: "DomainCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FPR2_HUMAN",
                column: "DomainCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRM2_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KDM1A_HUMAN",
                column: "DomainCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MTHR_HUMAN",
                column: "DomainCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MTR1A_HUMAN",
                column: "DomainCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NMDZ1_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRD_HUMAN",
                column: "DomainCount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRK_HUMAN",
                column: "DomainCount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRM_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "S10AA_HUMAN",
                column: "DomainCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SC6A4_HUMAN",
                column: "DomainCount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TPH1_HUMAN",
                column: "DomainCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TPH2_HUMAN",
                column: "DomainCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRPV1_HUMAN",
                column: "DomainCount",
                value: 2);

            migrationBuilder.InsertData(
                table: "DomainProtein",
                columns: new[] { "DomainId", "ProteinId" },
                values: new object[,]
                {
                    { "depressionkb", "5HT1A_HUMAN" },
                    { "depressionkb", "5HT2A_HUMAN" },
                    { "depressionkb", "5HT4R_HUMAN" },
                    { "depressionkb", "5HT6R_HUMAN" },
                    { "depressionkb", "ACHB2_HUMAN" },
                    { "depressionkb", "ACM1_HUMAN" },
                    { "depressionkb", "ACM4_HUMAN" },
                    { "depressionkb", "AOFA_HUMAN" },
                    { "depressionkb", "AOFB_HUMAN" },
                    { "depressionkb", "CNR2_HUMAN" },
                    { "depressionkb", "CP46A_HUMAN" },
                    { "depressionkb", "FKBP5_HUMAN" },
                    { "depressionkb", "FPR2_HUMAN" },
                    { "depressionkb", "GRM2_HUMAN" },
                    { "depressionkb", "KDM1A_HUMAN" },
                    { "depressionkb", "MTHR_HUMAN" },
                    { "depressionkb", "MTR1A_HUMAN" },
                    { "depressionkb", "NMDZ1_HUMAN" },
                    { "depressionkb", "OPRD_HUMAN" },
                    { "depressionkb", "OPRK_HUMAN" },
                    { "depressionkb", "OPRM_HUMAN" },
                    { "depressionkb", "S10AA_HUMAN" },
                    { "depressionkb", "SC6A4_HUMAN" },
                    { "depressionkb", "TPH1_HUMAN" },
                    { "depressionkb", "TPH2_HUMAN" },
                    { "depressionkb", "TRPV1_HUMAN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "5HT1A_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "5HT2A_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "5HT4R_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "5HT6R_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "ACHB2_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "ACM1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "ACM4_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "AOFA_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "AOFB_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "CNR2_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "CP46A_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "FKBP5_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "FPR2_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "GRM2_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "KDM1A_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "MTHR_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "MTR1A_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "NMDZ1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "OPRD_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "OPRK_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "OPRM_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "S10AA_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "SC6A4_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "TPH1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "TPH2_HUMAN" });

            migrationBuilder.DeleteData(
                table: "DomainProtein",
                keyColumns: new[] { "DomainId", "ProteinId" },
                keyValues: new object[] { "depressionkb", "TRPV1_HUMAN" });

            migrationBuilder.DeleteData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "depressionkb");

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT1A_HUMAN",
                column: "DomainCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT2A_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT4R_HUMAN",
                column: "DomainCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "5HT6R_HUMAN",
                column: "DomainCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACHB2_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACM1_HUMAN",
                column: "DomainCount",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "ACM4_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AOFA_HUMAN",
                column: "DomainCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "AOFB_HUMAN",
                column: "DomainCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CNR2_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "CP46A_HUMAN",
                column: "DomainCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FKBP5_HUMAN",
                column: "DomainCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "FPR2_HUMAN",
                column: "DomainCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "GRM2_HUMAN",
                column: "DomainCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "KDM1A_HUMAN",
                column: "DomainCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MTHR_HUMAN",
                column: "DomainCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "MTR1A_HUMAN",
                column: "DomainCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "NMDZ1_HUMAN",
                column: "DomainCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRD_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRK_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "OPRM_HUMAN",
                column: "DomainCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "S10AA_HUMAN",
                column: "DomainCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "SC6A4_HUMAN",
                column: "DomainCount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TPH1_HUMAN",
                column: "DomainCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TPH2_HUMAN",
                column: "DomainCount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Proteins",
                keyColumn: "Id",
                keyValue: "TRPV1_HUMAN",
                column: "DomainCount",
                value: 1);
        }
    }
}
