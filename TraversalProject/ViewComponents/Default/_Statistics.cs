using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProject.ViewComponents.Default
{
    public class _Statistics:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var count = new Context();
            ViewBag.rota = count.Destinations.Count();
            ViewBag.turRehber = count.Guides.Count();
            ViewBag.mutluMusteri = "285";
            ViewBag.odul = "25";
            return View();
        }
    }
}
