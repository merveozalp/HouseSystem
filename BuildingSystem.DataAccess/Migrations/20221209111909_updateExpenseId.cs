using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingSystem.DataAccess.Migrations
{
    public partial class updateExpenseId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenceTypeId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenceTypeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "ExpenceTypeId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "ExpenseId",
                table: "Expenses",
                newName: "ExpenseTypeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Messanges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<byte>(
                name: "FlatNumber",
                table: "Flats",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Messanges");

            migrationBuilder.RenameColumn(
                name: "ExpenseTypeId",
                table: "Expenses",
                newName: "ExpenseId");

            migrationBuilder.AlterColumn<int>(
                name: "FlatNumber",
                table: "Flats",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<byte>(
                name: "FloorNumber",
                table: "Flats",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "ExpenceTypeId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenceTypeId",
                table: "Expenses",
                column: "ExpenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenceTypeId",
                table: "Expenses",
                column: "ExpenceTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
