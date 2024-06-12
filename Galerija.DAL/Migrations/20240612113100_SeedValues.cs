using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Galerija.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArtPeriods",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 4, "Stil karakteriziran naglaskom na svjetlost i pokret", "Impresionizam" },
                    { 5, "Umjetnički pokret koji naglašava emocije i individualizam", "Romantizam" },
                    { 6, "Stil arhitekture i umjetnosti s visokim, tanušnim oblicima i šiljatim lukovima", "Gotika" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtPeriods",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ArtPeriods",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ArtPeriods",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
