using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Controllers
{
    [AllowAnonymous]
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }
        [HttpGet]
        public PartialViewResult Newsletter()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Newsletter(Newsletter newsletter)
        {
            _newsletterService.TAdd(newsletter);
            Response.Redirect("/Default/Index", true);
            return PartialView();
        }
    }
}
