using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using TraversalProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var about = _aboutService.TGetList();
            return View(about);
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var aboutID = _aboutService.TGetByID(id);
            AboutUpdateViewModel model = new AboutUpdateViewModel();
            model.AboutID = aboutID.AboutID;
            model.Title = aboutID.Title;
            model.Description = aboutID.Description;
            model.Image1 = aboutID.Image1;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutUpdateViewModel model)
        {
            About about = new About();
            if (model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = Guid.NewGuid() + extension; // benzersiz isim + uzantı
                var saveLocation = resource + "/wwwroot/UserImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create); // modunu: dosya oluşturma modunda açıp stream oluşturduk
                await model.Image.CopyToAsync(stream);
                about.Image1 = imageName;
            }
            about.AboutID=model.AboutID;
            about.Title = model.Title;
            about.Description = model.Description;
            about.Status = true;

            _aboutService.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}
