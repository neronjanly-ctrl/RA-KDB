using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DockingApiService.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DockingLigands",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fingerprint = table.Column<byte[]>(nullable: true),
                    Progress = table.Column<int>(nullable: false),
                    Smiles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockingLigands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DockingResults",
                columns: table => new
                {
                    LigandId = table.Column<long>(nullable: false),
                    ProteinId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Prediction = table.Column<int>(nullable: true),
                    Score1 = table.Column<float>(nullable: true),
                    Score2 = table.Column<float>(nullable: true),
                    Score3 = table.Column<float>(nullable: true),
                    Score4 = table.Column<float>(nullable: true),
                    SimilarChemblId = table.Column<int>(nullable: true),
                    SimilarFingerprint = table.Column<byte[]>(nullable: true),
                    SimilarSmiles = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTimeOffset>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "DockingTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    LigandId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Started = table.Column<DateTimeOffset>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DockingTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DockingTasks_DockingLigands_LigandId",
                        column: x => x.LigandId,
                        principalTable: "DockingLigands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DockingTasks_LigandId",
                table: "DockingTasks",
                column: "LigandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DockingResults");

            migrationBuilder.DropTable(
                name: "DockingTasks");

            migrationBuilder.DropTable(
                name: "DockingLigands");
        }
    }
}
