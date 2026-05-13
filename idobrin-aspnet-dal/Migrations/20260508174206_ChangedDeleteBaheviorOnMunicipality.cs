using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace idobrin_aspnet_dal.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDeleteBaheviorOnMunicipality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipalities_Countries_CountryId",
                table: "Municipalities");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipalities_Countries_CountryId",
                table: "Municipalities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipalities_Countries_CountryId",
                table: "Municipalities");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipalities_Countries_CountryId",
                table: "Municipalities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
