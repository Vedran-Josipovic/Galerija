﻿// <auto-generated />
using System;
using Galerija.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Galerija.DAL.Migrations
{
    [DbContext(typeof(GalleryManagerDbContext))]
    [Migration("20240612113100_SeedValues")]
    partial class SeedValues
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Galerija.Model.ArtPeriod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ArtPeriods");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Razdoblje kulturnog preporoda i umjetničke izvrsnosti",
                            Name = "Renesansa"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Obilježeno raskošjem i grandioznošću",
                            Name = "Barok"
                        },
                        new
                        {
                            ID = 3,
                            Description = "Odlazak od tradicionalnih oblika i prihvaćanje novih",
                            Name = "Modernizam"
                        },
                        new
                        {
                            ID = 4,
                            Description = "Stil karakteriziran naglaskom na svjetlost i pokret",
                            Name = "Impresionizam"
                        },
                        new
                        {
                            ID = 5,
                            Description = "Umjetnički pokret koji naglašava emocije i individualizam",
                            Name = "Romantizam"
                        },
                        new
                        {
                            ID = 6,
                            Description = "Stil arhitekture i umjetnosti s visokim, tanušnim oblicima i šiljatim lukovima",
                            Name = "Gotika"
                        });
                });

            modelBuilder.Entity("Galerija.Model.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Galerija.Model.Artwork", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ArtistID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExhibitionID")
                        .HasColumnType("int");

                    b.Property<int?>("MuseumID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeriodID")
                        .HasColumnType("int");

                    b.Property<int>("YearCompleted")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArtistID");

                    b.HasIndex("ExhibitionID");

                    b.HasIndex("MuseumID");

                    b.HasIndex("PeriodID");

                    b.ToTable("Artworks");
                });

            modelBuilder.Entity("Galerija.Model.Exhibition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MuseumID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("MuseumID");

                    b.ToTable("Exhibitions");
                });

            modelBuilder.Entity("Galerija.Model.ImageAttachment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ArtworkID")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ArtworkID");

                    b.ToTable("ImageAttachments");
                });

            modelBuilder.Entity("Galerija.Model.Museum", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Museums");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Avenija Dubrovnik 17, 10000 Zagreb",
                            Description = "Muzej suvremene umjetnosti u Zagrebu",
                            Email = "info@msu.hr",
                            Name = "Muzej Suvremene Umjetnosti Zagreb",
                            Phone = "+385 1 6052 700"
                        },
                        new
                        {
                            ID = 2,
                            Address = "Dolac 1/II, 51000 Rijeka",
                            Description = "Muzej suvremene umjetnosti u Rijeci",
                            Email = "info@msu.hr",
                            Name = "Muzej Suvremene Umjetnosti Rijeka",
                            Phone = "+385 51 492 615"
                        },
                        new
                        {
                            ID = 3,
                            Address = "Kralja Tomislava 15, 21000 Split",
                            Description = "Muzej suvremene umjetnosti u Splitu",
                            Email = "info@msu.hr",
                            Name = "Muzej Suvremene Umjetnosti Split",
                            Phone = "+385 21 344 164"
                        });
                });

            modelBuilder.Entity("Galerija.Model.Artwork", b =>
                {
                    b.HasOne("Galerija.Model.Artist", "Artist")
                        .WithMany("Artworks")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Galerija.Model.Exhibition", null)
                        .WithMany("Artworks")
                        .HasForeignKey("ExhibitionID");

                    b.HasOne("Galerija.Model.Museum", null)
                        .WithMany("Artworks")
                        .HasForeignKey("MuseumID");

                    b.HasOne("Galerija.Model.ArtPeriod", "ArtPeriod")
                        .WithMany("Artworks")
                        .HasForeignKey("PeriodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtPeriod");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Galerija.Model.Exhibition", b =>
                {
                    b.HasOne("Galerija.Model.Museum", "Museum")
                        .WithMany("Exhibitions")
                        .HasForeignKey("MuseumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Museum");
                });

            modelBuilder.Entity("Galerija.Model.ImageAttachment", b =>
                {
                    b.HasOne("Galerija.Model.Artwork", "Artwork")
                        .WithMany("Images")
                        .HasForeignKey("ArtworkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artwork");
                });

            modelBuilder.Entity("Galerija.Model.ArtPeriod", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("Galerija.Model.Artist", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("Galerija.Model.Artwork", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Galerija.Model.Exhibition", b =>
                {
                    b.Navigation("Artworks");
                });

            modelBuilder.Entity("Galerija.Model.Museum", b =>
                {
                    b.Navigation("Artworks");

                    b.Navigation("Exhibitions");
                });
#pragma warning restore 612, 618
        }
    }
}
