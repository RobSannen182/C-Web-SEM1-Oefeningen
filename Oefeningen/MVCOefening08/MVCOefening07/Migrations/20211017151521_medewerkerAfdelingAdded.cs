using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCOefening07.Migrations
{
    public partial class medewerkerAfdelingAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedewerkerAfdeling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedewerkerId = table.Column<int>(nullable: false),
                    AfdelingId = table.Column<int>(nullable: false),
                    StartDatum = table.Column<DateTime>(nullable: false),
                    EindDatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerAfdeling", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedewerkerAfdeling");
        }
    }
}
