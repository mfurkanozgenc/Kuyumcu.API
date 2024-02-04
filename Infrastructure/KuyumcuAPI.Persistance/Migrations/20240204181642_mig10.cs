using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuyumcuAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashTransactions_Customers_CustomerId",
                table: "CashTransactions");

            migrationBuilder.DropIndex(
                name: "IX_CashTransactions_CustomerId",
                table: "CashTransactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CashTransactions_CustomerId",
                table: "CashTransactions",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CashTransactions_Customers_CustomerId",
                table: "CashTransactions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
