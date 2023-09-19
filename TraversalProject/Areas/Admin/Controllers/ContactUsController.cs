using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var contactUs = _contactUsService.TGetListContactUsByTrue(); // durumu True olan mesajlar gelsin
            return View(contactUs);
        }
        public IActionResult ContactUsDelete(int id)
        {
            _contactUsService.TContactUsStatusChangeToFalse(id); 
            return RedirectToAction("Index");
        }
        public IActionResult ContactUsDetails(int id)
        {
            var contact=_contactUsService.TContactUsMessageDetails(id);
            return View(contact);
        }
        public IActionResult ContactUsByFalse()
        {
            var contactUs = _contactUsService.TGetListContactUsByFalse();
            return View(contactUs);
        }
    }
}
