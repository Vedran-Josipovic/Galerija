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

        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
            var exhibition = _dbContext.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return NotFound();
            }
            FillDropdownValuesMuseums();
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
            return View(exhibition);
        }

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

        [ActionName(nameof(Create))]
        public IActionResult Create()
        {
            FillDropdownValuesMuseums();
            return View();
        }
        
        [HttpPost]
        [ActionName(nameof(Create))]
        public async Task<IActionResult> CreatePost(Exhibition model)
        {
            var museum = await _dbContext.Museums.FindAsync(model.MuseumID);

            if (museum == null)
            {
                ModelState.AddModelError("MuseumID", "Invalid Museum");
            }

            model.Museum = museum;
            ModelState.Remove(nameof(model.ID));
            ModelState.Remove(nameof(model.Museum));

            if (this.ModelState.IsValid)
            {
                _dbContext.Exhibitions.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            FillDropdownValuesMuseums();
            return View(model);
        }

        [ActionName(nameof(Delete))]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var exhibition = _dbContext.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return NotFound();
            }

            _dbContext.Exhibitions.Remove(exhibition);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }




}
