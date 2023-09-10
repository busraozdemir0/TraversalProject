using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberLayoutNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                var userName = User.Identity.Name;
                ViewBag.name = context.Users.Where(x => x.UserName == userName).Select(y => y.Name).FirstOrDefault();
                ViewBag.surname = context.Users.Where(x => x.UserName == userName).Select(y => y.Surname).FirstOrDefault();
                ViewBag.image = context.Users.Where(x => x.UserName == userName).Select(y => y.ImageURL).FirstOrDefault();

                ViewBag.announcementCount=context.Announcements.Count();
            }
            return View();
        }
    }
}
