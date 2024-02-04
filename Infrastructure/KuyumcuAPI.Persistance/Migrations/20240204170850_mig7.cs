using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuyumcuAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CashTransactionType",
                table: "CashTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashTransactionType",
                table: "CashTransactions");
        }
    }
}
