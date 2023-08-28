using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
