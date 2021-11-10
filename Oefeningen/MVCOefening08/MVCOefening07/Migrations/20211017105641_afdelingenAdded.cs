using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCOefening07.Migrations
{
    public partial class afdelingenAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afdelingen",
                columns: table => new
                {
                    AfdelingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AfdelingNaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afdelingen", x => x.AfdelingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afdelingen");
        }
    }
}
