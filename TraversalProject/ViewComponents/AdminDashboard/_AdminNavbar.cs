using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProject.ViewComponents.AdminDashboard
{
    public class _AdminNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                var userName = User.Identity.Name;
                var name = context.Users.Where(x => x.UserName == userName).Select(y => y.Name).FirstOrDefault();
                var surname = context.Users.Where(x => x.UserName == userName).Select(y => y.Surname).FirstOrDefault();
                var imageUrl = context.Users.Where(x => x.UserName == userName).Select(y => y.ImageURL).FirstOrDefault();

                ViewBag.name = name;
                ViewBag.surname = surname;
                ViewBag.image = imageUrl;
            }
            return View();
        }
    }
}
