using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuyumcuAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashTransactions_Customers_CustomerId",
                table: "CashTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CashTransactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CashTransactions_Customers_CustomerId",
                table: "CashTransactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashTransactions_Customers_CustomerId",
                table: "CashTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CashTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CashTransactions_Customers_CustomerId",
                table: "CashTransactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
