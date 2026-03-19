using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DockingApiService.Migrations
{
    public partial class ProteinTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProteinTags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteinTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProteinProteinTag",
                columns: table => new
                {
                    ProteinsId = table.Column<string>(type: "TEXT", nullable: false),
                    TagsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProteinProteinTag", x => new { x.ProteinsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ProteinProteinTag_Proteins_ProteinsId",
                        column: x => x.ProteinsId,
                        principalTable: "Proteins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProteinProteinTag_ProteinTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "ProteinTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProteinProteinTag_TagsId",
                table: "ProteinProteinTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProteinProteinTag");

            migrationBuilder.DropTable(
                name: "ProteinTags");
        }
    }
}
