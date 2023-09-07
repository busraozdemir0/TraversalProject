using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
