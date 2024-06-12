using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Galerija.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArtPeriods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtPeriods", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Museums",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Museums", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Exhibitions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MuseumID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibitions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exhibitions_Museums_MuseumID",
                        column: x => x.MuseumID,
                        principalTable: "Museums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearCompleted = table.Column<int>(type: "int", nullable: false),
                    PeriodID = table.Column<int>(type: "int", nullable: false),
                    ArtistID = table.Column<int>(type: "int", nullable: false),
                    ExhibitionID = table.Column<int>(type: "int", nullable: true),
                    MuseumID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Artworks_ArtPeriods_PeriodID",
                        column: x => x.PeriodID,
                        principalTable: "ArtPeriods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artworks_Artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artworks_Exhibitions_ExhibitionID",
                        column: x => x.ExhibitionID,
                        principalTable: "Exhibitions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Artworks_Museums_MuseumID",
                        column: x => x.MuseumID,
                        principalTable: "Museums",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ImageAttachments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtworkID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageAttachments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ImageAttachments_Artworks_ArtworkID",
                        column: x => x.ArtworkID,
                        principalTable: "Artworks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArtPeriods",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Razdoblje kulturnog preporoda i umjetničke izvrsnosti", "Renesansa" },
                    { 2, "Obilježeno raskošjem i grandioznošću", "Barok" },
                    { 3, "Odlazak od tradicionalnih oblika i prihvaćanje novih", "Modernizam" }
                });

            migrationBuilder.InsertData(
                table: "Museums",
                columns: new[] { "ID", "Address", "Description", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Avenija Dubrovnik 17, 10000 Zagreb", "Muzej suvremene umjetnosti u Zagrebu", "info@msu.hr", "Muzej Suvremene Umjetnosti Zagreb", "+385 1 6052 700" },
                    { 2, "Dolac 1/II, 51000 Rijeka", "Muzej suvremene umjetnosti u Rijeci", "info@msu.hr", "Muzej Suvremene Umjetnosti Rijeka", "+385 51 492 615" },
                    { 3, "Kralja Tomislava 15, 21000 Split", "Muzej suvremene umjetnosti u Splitu", "info@msu.hr", "Muzej Suvremene Umjetnosti Split", "+385 21 344 164" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtistID",
                table: "Artworks",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ExhibitionID",
                table: "Artworks",
                column: "ExhibitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_MuseumID",
                table: "Artworks",
                column: "MuseumID");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_PeriodID",
                table: "Artworks",
                column: "PeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibitions_MuseumID",
                table: "Exhibitions",
                column: "MuseumID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageAttachments_ArtworkID",
                table: "ImageAttachments",
                column: "ArtworkID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageAttachments");

            migrationBuilder.DropTable(
                name: "Artworks");

            migrationBuilder.DropTable(
                name: "ArtPeriods");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Exhibitions");

            migrationBuilder.DropTable(
                name: "Museums");
        }
    }
}
