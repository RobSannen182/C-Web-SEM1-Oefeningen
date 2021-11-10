using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class addedForeignKeyExpensesExpenseTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExpenseTypeId",
                table: "Expences",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Expences_ExpenseTypeId",
                table: "Expences",
                column: "ExpenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expences_ExpenseTypes_ExpenseTypeId",
                table: "Expences",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expences_ExpenseTypes_ExpenseTypeId",
                table: "Expences");

            migrationBuilder.DropIndex(
                name: "IX_Expences_ExpenseTypeId",
                table: "Expences");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseTypeId",
                table: "Expences",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
