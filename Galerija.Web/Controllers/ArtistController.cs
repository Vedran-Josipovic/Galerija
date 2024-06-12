using Galerija.DAL;
using Galerija.Model;
using Microsoft.AspNetCore.Mvc;

namespace Galerija.Web.Controllers
{
    public class ArtistController(GalleryManagerDbContext _dbContext) : Controller
    {
        public IActionResult Index()
        {
            /*_dbContext.Add(new Artist
            {
                FirstName = "Pablo",
                LastName = "Picasso",
                Biography = "Pablo Picasso was a Spanish painter, sculptor, printmaker, ceramicist and stage designer who spent most of his adult life in France. Regarded as one of the most influential artists of the 20th century, he is known for co-founding the Cubist movement, the invention of constructed sculpture, the co-invention of collage, and for the wide variety of styles that he helped develop and explore.",
                DateOfBirth = new DateTime(1881, 10, 25),
                DateOfDeath = new DateTime(1973, 4, 8)
            });
            _dbContext.SaveChanges();*/


            var model = _dbContext.Artists.ToList();
            return View(model);
        }
    }
}
