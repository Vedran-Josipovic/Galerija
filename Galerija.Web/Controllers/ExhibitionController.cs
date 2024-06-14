using Galerija.DAL;
using Galerija.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Net.Mail;

namespace Galerija.Web.Controllers
{
    public class ExhibitionController(GalleryManagerDbContext _dbContext, IWebHostEnvironment _webHostEnvironment) : Controller
    {
        public IActionResult Index()
        {
            var model = _dbContext.Exhibitions.Include(e => e.Museum).ToList();
            return View(model);
        }

        private void FillDropdownValuesMuseums()
        {
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var museum in _dbContext.Museums)
            {
                listItem = new SelectListItem(museum.Name, museum.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossibleMuseums = selectItems;
        }

        private void FillDropdownValuesArtworks()
        {
            var selectItems = new List<SelectListItem>();

            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var artwork in _dbContext.Artworks)
            {
                listItem = new SelectListItem(artwork.Name, artwork.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossibleArtworks = selectItems;
        }

        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var exhibition = _dbContext.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return NotFound();
            }
            FillDropdownValuesMuseums();
            FillDropdownValuesArtworks();
            return View(exhibition);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var exhibition = _dbContext.Exhibitions.Include(e => e.Museum).FirstOrDefault(e => e.ID == id);
            var ok = await this.TryUpdateModelAsync(exhibition);

            if (ok && this.ModelState.IsValid)
            {
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            FillDropdownValuesMuseums();
            FillDropdownValuesArtworks();
            return View(exhibition);
        }

        //details
        public IActionResult Details(int id)
        {
            var exhibition = _dbContext.Exhibitions
                .Include(e => e.Museum)
                .Include(e => e.Artworks)
                .FirstOrDefault(e => e.ID == id);
            if (exhibition == null)
            {
                return NotFound();
            }
            return View(exhibition);
        }



    }




}
