using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DockingApiService.Migrations
{
    public partial class UpdateVirusCKBDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb",
                columns: new[] { "Description", "Name" },
                values: new object[] { "Virus-CKB 2.0 is a knowledgebase for viral-related diseases research that is implemented with our established chemogenomics tools as well as our algorithms for data visualization and analyses, including MCCS, HTDocking, TargetHunter, BBB predictor, Spider Plot, Protein-Protein docking, etc. This tool predicts the BioActivities on 178 viral related targets for a query compound and provides a handy user interface for viewing, downloading and plotting the output results.<br/><video class=\"w-100\" controls autoplay loop><source src=\"images/w03.mp4\" /></video>", "Virus Chemogenomics Knowledgebase 2.0" });

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb2",
                columns: new[] { "Description", "Name" },
                values: new object[] { "Virus-CKB 2.0 is a knowledgebase for viral-related diseases research that is implemented with our established chemogenomics tools as well as our algorithms for data visualization and analyses, including MCCS, HTDocking, TargetHunter, BBB predictor, Spider Plot, Protein-Protein docking, etc. This tool predicts the BioActivities on 178 viral related targets for a query compound and provides a handy user interface for viewing, downloading and plotting the output results.", "Virus Chemogenomics Knowledgebase Expansion" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb",
                columns: new[] { "Description", "Name" },
                values: new object[] { "Virus-CKB is a knowledgebase for COVID-19 and similar viral infection research that implemented with our established chemogenomics tools as well as our algorithms for data visualization and analyses. This tool predicts the BioActivities on 92 viral related targets for a query compound and provides a handy user interface for viewing, downloading and plotting the output results.<br/><video class=\"w-100\" controls autoplay loop><source src=\"images/w03.mp4\" /></video>", "Virus Chemogenomics Knowledgebase" });

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: "virus-ckb2",
                columns: new[] { "Description", "Name" },
                values: new object[] { "Virus-CKB2 is an expansion of [Virus-CKB](/virus-ckb)", "Virus Chemogenomics Knowledgebase 2" });
        }
    }
}
