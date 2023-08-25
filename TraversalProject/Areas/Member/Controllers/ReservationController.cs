using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);  // ada göre giren kullanıcıyı bulduk
            var reservationList = reservationManager.GetListWithReservationByAccepted(userName.Id);
            return View(reservationList);
        }
        public async Task<IActionResult> MyOldReservation()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);  // ada göre giren kullanıcıyı bulduk
            var reservationList = reservationManager.GetListWithReservationByPrevious(userName.Id);
            ViewBag.reservationCount = reservationManager.GetListWithReservationByPrevious(userName.Id).Count();
            return View(reservationList);
        }
        public async Task<IActionResult> MyApprovalReservation() // onay bekleyen rezervasyonlar
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);  // ada göre giren kullanıcıyı bulduk
            var reservationList=reservationManager.GetListWithReservationByWaitApproval(userName.Id);
            return View(reservationList);
        }
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text= x.City,
                                               Value= x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.destinations = values;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserId = 1;
            p.Status = "Onay Bekliyor";
            reservationManager.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}
