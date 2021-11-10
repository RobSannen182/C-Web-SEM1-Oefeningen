using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCVoertuig.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voertuigen",
                columns: table => new
                {
                    VoertuigId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Merk = table.Column<string>(nullable: false),
                    MerkType = table.Column<string>(nullable: false),
                    Bouwjaar = table.Column<int>(nullable: false),
                    Km = table.Column<int>(nullable: false),
                    VerkoopPrijs = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    AanwezigInShowroom = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuigen", x => x.VoertuigId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voertuigen");
        }
    }
}
