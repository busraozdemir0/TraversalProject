using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }
        public IActionResult Index()
        {
            var values=_newsletterService.TGetList();
            return View(values);
        }
        public IActionResult DeleteNewsletter(int id)
        {
            var mail = _newsletterService.TGetByID(id);
            _newsletterService.TDelete(mail);
            return RedirectToAction("Index");
        }
    }
}
