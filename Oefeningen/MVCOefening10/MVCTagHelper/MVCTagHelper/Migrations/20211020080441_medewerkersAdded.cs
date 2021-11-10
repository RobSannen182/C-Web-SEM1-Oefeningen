using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCTagHelper.Migrations
{
    public partial class medewerkersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    MedewerkerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AfdelingId = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.MedewerkerId);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Afdelingen_AfdelingId",
                        column: x => x.AfdelingId,
                        principalTable: "Afdelingen",
                        principalColumn: "AfdelingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_AfdelingId",
                table: "Medewerkers",
                column: "AfdelingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medewerkers");
        }
    }
}
