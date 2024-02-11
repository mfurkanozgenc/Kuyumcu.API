using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuyumcuAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isGram",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCount",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isGram",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
