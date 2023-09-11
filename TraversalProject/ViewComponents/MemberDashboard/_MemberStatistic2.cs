using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProject.ViewComponents.MemberDashboard
{
    public class _MemberStatistic2 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using(var context=new Context())
            {
                var tours = context.Destinations.Take(3).ToList();
                ViewBag.tourImage = context.Destinations.OrderByDescending(y=>y.Date).Select(y => y.CoverImage).FirstOrDefault();
                return View(tours);
            }

        }
    }
}
