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
                FirstName = "Ivan",
                LastName = "Meštrović",
                Biography = "Ivan Meštrović was a Croatian sculptor, architect and writer of the 20th century. He was the most prominent sculptor of Croatian modern sculpture and one of the most famous sculptors in the world.",
                DateOfBirth = new DateTime(1883, 8, 15),
                DateOfDeath = new DateTime(1962, 1, 16)
            });
            _dbContext.SaveChanges();*/


            var model = _dbContext.Artists.ToList();
			return View(model);
		}
    }
}
