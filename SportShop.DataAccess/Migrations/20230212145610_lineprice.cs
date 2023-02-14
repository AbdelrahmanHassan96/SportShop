using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class lineprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LinePrice",
                table: "CartLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinePrice",
                table: "CartLines");
        }
    }
}
