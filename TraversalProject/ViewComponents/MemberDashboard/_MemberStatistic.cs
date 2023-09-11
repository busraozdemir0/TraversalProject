using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalProject.ViewComponents.MemberDashboard
{
    public class _MemberStatistic : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberStatistic(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                var userName = _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.aktifRezv = context.Reservations.Include(x => x.Destination).Where(y => y.Status == "Onaylandı" && y.AppUserId == userName.Id).Count(); // onaylanan rezervasyon sayısı
                ViewBag.geçmişRezv = context.Reservations.Include(x => x.Destination).Where(y => y.Status == "Geçmiş Rezervasyon" && y.AppUserId == userName.Id).Count(); // geçmiş rezervasyon sayısı
                ViewBag.onayBekleyenRezv = context.Reservations.Include(x => x.Destination).Where(y => y.Status == "Onay Bekliyor" && y.AppUserId == userName.Id).Count(); // onay bekleyen rezervasyon sayısı
                ViewBag.totalComment=context.Comments.Include(x=>x.AppUser).Where(x=>x.AppUserID== userName.Id).Count(); // giren kişinin yaptığı toplam yorum sayısı
                ViewBag.notificationComment = context.Announcements.Count();
                ViewBag.totalTour = context.Destinations.Count();
                ViewBag.totalGuide = context.Guides.Count();
                ViewBag.totalMember =context.Users.Count();

                return View();
            }
        }
    }
}
