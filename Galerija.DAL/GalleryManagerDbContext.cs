using Microsoft.EntityFrameworkCore;
using Galerija.Model;

namespace Galerija.DAL
{
    public class GalleryManagerDbContext : DbContext
    {
        public GalleryManagerDbContext(DbContextOptions<GalleryManagerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<ArtPeriod> ArtPeriods { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<ImageAttachment> ImageAttachments { get; set; }
        public DbSet<Museum> Museums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ArtPeriod>().HasData(
	        new ArtPeriod { ID = 1, Name = "Renesansa", Description = "Razdoblje kulturnog preporoda i umjetničke izvrsnosti" },
	        new ArtPeriod { ID = 2, Name = "Barok", Description = "Obilježeno raskošjem i grandioznošću" },
	        new ArtPeriod { ID = 3, Name = "Modernizam", Description = "Odlazak od tradicionalnih oblika i prihvaćanje novih" },
	        new ArtPeriod { ID = 4, Name = "Impresionizam", Description = "Stil karakteriziran naglaskom na svjetlost i pokret" },
	        new ArtPeriod { ID = 5, Name = "Romantizam", Description = "Umjetnički pokret koji naglašava emocije i individualizam" },
	        new ArtPeriod { ID = 6, Name = "Gotika", Description = "Stil arhitekture i umjetnosti s visokim, tanušnim oblicima i šiljatim lukovima" }
            );

			modelBuilder.Entity<Museum>().HasData(
                new Museum { ID = 1, Name = "Muzej Suvremene Umjetnosti Zagreb", Description = "Muzej suvremene umjetnosti u Zagrebu", Address = "Avenija Dubrovnik 17, 10000 Zagreb", Email = "info@msu.hr", Phone = "+385 1 6052 700" },
                new Museum { ID = 2, Name = "Muzej Suvremene Umjetnosti Rijeka", Description = "Muzej suvremene umjetnosti u Rijeci", Address = "Dolac 1/II, 51000 Rijeka", Email = "info@msu.hr", Phone = "+385 51 492 615" },
                new Museum { ID = 3, Name = "Muzej Suvremene Umjetnosti Split", Description = "Muzej suvremene umjetnosti u Splitu", Address = "Kralja Tomislava 15, 21000 Split", Email = "info@msu.hr", Phone = "+385 21 344 164" }
            );
        }
    }
}
