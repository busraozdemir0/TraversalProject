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
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                var userName = User.Identity.Name;
                var userID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
                ViewBag.aktifRezv = context.Reservations.Include(x => x.Destination).Where(y => y.Status == "Onaylandı" && y.AppUserId == userID).Count(); // onaylanan rezervasyon sayısı
                ViewBag.geçmişRezv = context.Reservations.Include(x => x.Destination).Where(y => y.Status == "Geçmiş Rezervasyon" && y.AppUserId == userID).Count(); // geçmiş rezervasyon sayısı
                ViewBag.onayBekleyenRezv = context.Reservations.Include(x => x.Destination).Where(y => y.Status == "Onay Bekliyor" && y.AppUserId == userID).Count(); // onay bekleyen rezervasyon sayısı
                ViewBag.totalComment=context.Comments.Include(x=>x.AppUser).Where(x=>x.AppUserID == userID).Count(); // giren kişinin yaptığı toplam yorum sayısı
                ViewBag.notificationCount = context.Announcements.Count();
                ViewBag.totalTour = context.Destinations.Count();
                ViewBag.totalGuide = context.Guides.Count();
                ViewBag.totalMember =context.Users.Count();

                return View();
            }
        }
    }
}
