using Microsoft.EntityFrameworkCore.Migrations;

namespace DockingApiService.Migrations
{
    public partial class AddBbbScoresAndDepictionSvg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "BbbAdaboostDayLight",
                table: "DockingLigands",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BbbAdaboostMACCS",
                table: "DockingLigands",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BbbAdaboostMolprint2D",
                table: "DockingLigands",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BbbAdaboostPubChem",
                table: "DockingLigands",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BbbSVMDayLight",
                table: "DockingLigands",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BbbSVMMACCS",
                table: "DockingLigands",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BbbSVMMolprint2D",
                table: "DockingLigands",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BbbSVMPubChem",
                table: "DockingLigands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepictionSvg",
                table: "DockingLigands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepictionSvg3D",
                table: "DockingLigands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BbbAdaboostDayLight",
                table: "DockingLigands");

            migrationBuilder.DropColumn(
                name: "BbbAdaboostMACCS",
                table: "DockingLigands");

            migrationBuilder.DropColumn(
                name: "BbbAdaboostMolprint2D",
                table: "DockingLigands");

            migrationBuilder.DropColumn(
                name: "BbbAdaboostPubChem",
                table: "DockingLigands");

            migrationBuilder.DropColumn(
                name: "BbbSVMDayLight",
                table: "DockingLigands");

            migrationBuilder.DropColumn(
                name: "BbbSVMMACCS",
                table: "DockingLigands");

            migrationBuilder.DropColumn(
                name: "BbbSVMMolprint2D",
                table: "DockingLigands");

            migrationBuilder.DropColumn(
                name: "BbbSVMPubChem",
                table: "DockingLigands");

            migrationBuilder.DropColumn(
                name: "DepictionSvg",
                table: "DockingLigands");

            migrationBuilder.DropColumn(
                name: "DepictionSvg3D",
                table: "DockingLigands");
        }
    }
}
