using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace idobrin_aspnet_dal.Migrations
{
    /// <inheritdoc />
    public partial class CategoryProductsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CategoryProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
