using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin,Member, Manager, Editor , Visitor")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = userName.Name + " "+ userName.Surname;
            ViewBag.userImage = userName.ImageURL;
            return View();
        }
        public async Task<IActionResult> MemberDashboard()  // yeni temlate ile dashboard tasarımı
        {
            return View();
        }
    }
}
