using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class changedExpenseTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expences_ExpenseTypes_ExpenseTypeId",
                table: "Expences");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseTypeId",
                table: "Expences",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expences_ExpenseTypes_ExpenseTypeId",
                table: "Expences",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expences_ExpenseTypes_ExpenseTypeId",
                table: "Expences");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseTypeId",
                table: "Expences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Expences_ExpenseTypes_ExpenseTypeId",
                table: "Expences",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
