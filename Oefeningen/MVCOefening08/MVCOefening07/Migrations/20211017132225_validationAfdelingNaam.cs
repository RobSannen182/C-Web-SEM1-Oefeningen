using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCOefening07.Migrations
{
    public partial class validationAfdelingNaam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AfdelingNaam",
                table: "Afdelingen",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AfdelingNaam",
                table: "Afdelingen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
