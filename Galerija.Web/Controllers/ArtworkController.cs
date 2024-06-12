using Galerija.DAL;
using Galerija.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Net.Mail;

namespace Galerija.Web.Controllers
{
    public class ArtworkController(GalleryManagerDbContext _dbContext, IWebHostEnvironment _webHostEnvironment) : Controller
    {
		public IActionResult Index()
        {
            /*_dbContext.Add(
                new Artwork
                {
                    Name = "Guernica",
                    Description = "Guernica is a large 1937 oil painting on canvas by Spanish artist Pablo Picasso. One of Picasso's best-known works, Guernica is regarded by many art critics as one of the most moving and powerful anti-war paintings in history. It is exhibited in the Museo Reina Sofia in Madrid.",
                    YearCompleted = 1937,
                    PeriodID = 3,
                    ArtistID = 2
                }
            );
            _dbContext.SaveChanges();*/
            var model = _dbContext.Artworks.Include(a => a.Artist).Include(a => a.ArtPeriod).ToList();
			return View(model);
        }


        //public IActionResult Details(int id)
        //{
        //    var artwork = _dbContext.Artworks.Include(a => a.Artist).Include(a => a.ArtPeriod).Include(a => a.Images).FirstOrDefault(a => a.ID == id);
        //    if (artwork == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(artwork);
        //}

        private void FillDropdownValuesArtPeriods()
        {
            var selectItems = new List<SelectListItem>();

            //Polje je opcionalno
            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var period in _dbContext.ArtPeriods)
            {
                listItem = new SelectListItem(period.Name, period.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossibleArtPeriods = selectItems;
        }
        private void FillDropdownValuesArtists()
        {
            var selectItems = new List<SelectListItem>();

            //Polje je opcionalno
            var listItem = new SelectListItem();
            listItem.Text = "- odaberite -";
            listItem.Value = "";
            selectItems.Add(listItem);

            foreach (var artist in _dbContext.Artists)
            {
                listItem = new SelectListItem(artist.FullName, artist.ID.ToString());
                selectItems.Add(listItem);
            }

            ViewBag.PossibleArtists = selectItems;
        }

        [ActionName(nameof(Edit))]
        public IActionResult Edit(int id)
        {
			var artwork = _dbContext.Artworks.Find(id);
			if (artwork == null)
			{
				return NotFound();
			}
			this.FillDropdownValuesArtists();
			this.FillDropdownValuesArtPeriods();
			return View(artwork);
		}

        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var artwork = _dbContext.Artworks.Include(a => a.Artist).Include(a => a.ArtPeriod).First(a => a.ID == id);
            var ok = await this.TryUpdateModelAsync(artwork);

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

            this.FillDropdownValuesArtists();
            this.FillDropdownValuesArtPeriods();
            return View(artwork);
        }



        [HttpPost]
		public async Task<IActionResult> UploadAttachment(int artworkID, IFormFile file)
		{
			if (file != null && file.Length > 0)
			{
				var attachmentPath = Path.Combine(_webHostEnvironment.WebRootPath, "Attachments", file.FileName);
				using (var stream = new FileStream(attachmentPath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				var attachment = new ImageAttachment
				{
					ArtworkID = artworkID,
					FileName = file.FileName,
					FilePath = "wwwroot/Attachments/" + file.FileName
				};
				_dbContext.ImageAttachments.Add(attachment);
				await _dbContext.SaveChangesAsync();

				return RedirectToAction(nameof(Details), new { id = artworkID });
			}

			return RedirectToAction(nameof(Details), new { id = artworkID });
		}

		public IActionResult GetAttachments(int artworkID)
		{
			var attachments = _dbContext.ImageAttachments.Where(a => a.ArtworkID == artworkID).ToList();
			return PartialView("_AttachmentList", attachments);
		}


        //public IActionResult DeleteAttachment(int attachmentID, int artworkID)
        //{
        //	var attachment = _dbContext.ImageAttachments.Find(attachmentID);
        //	if (attachment != null)
        //	{
        //		var attachmentPath = Path.Combine(_webHostEnvironment.WebRootPath, "Attachments", attachment.FileName);
        //		if (System.IO.File.Exists(attachmentPath))
        //		{
        //			System.IO.File.Delete(attachmentPath);
        //		}

        //		_dbContext.ImageAttachments.Remove(attachment);
        //		_dbContext.SaveChanges();
        //	}

        //	return RedirectToAction(nameof(Details), new { id = artworkID });
        //}

        [HttpPost]
        public IActionResult DeleteAttachment(int attachmentID, int artworkID)
        {
            var attachment = _dbContext.ImageAttachments.Find(attachmentID);
            if (attachment != null)
            {
                var attachmentPath = Path.Combine(_webHostEnvironment.WebRootPath, "Attachments", attachment.FileName);
                if (System.IO.File.Exists(attachmentPath))
                {
                    System.IO.File.Delete(attachmentPath);
                }

                _dbContext.ImageAttachments.Remove(attachment);
                _dbContext.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        public IActionResult Details(int id)
        {
            var artwork = _dbContext.Artworks
                .Include(a => a.Artist)
                .Include(a => a.ArtPeriod)
                .Include(a => a.Images)
                .FirstOrDefault(a => a.ID == id);
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

    }
}
