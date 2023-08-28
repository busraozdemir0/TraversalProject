using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProject.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.destinationCount = context.Destinations.Count();
            ViewBag.userCount = context.Users.Count();

            return View();
        }
    }
}
