using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin,Member, Manager, Editor , Visitor")]
    public class ReservationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager, IDestinationService destinationService, IReservationService reservationService)
        {
            _userManager = userManager;
            _destinationService = destinationService;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);  // ada göre giren kullanıcıyı bulduk
            var reservationList = _reservationService.GetListWithReservationByAccepted(userName.Id);
            return View(reservationList);
        }
        public async Task<IActionResult> MyOldReservation()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);  // ada göre giren kullanıcıyı bulduk
            var reservationList = _reservationService.GetListWithReservationByPrevious(userName.Id);
            ViewBag.reservationCount = _reservationService.GetListWithReservationByPrevious(userName.Id).Count();
            return View(reservationList);
        }
        public async Task<IActionResult> MyApprovalReservation() // onay bekleyen rezervasyonlar
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);  // ada göre giren kullanıcıyı bulduk
            var reservationList= _reservationService.GetListWithReservationByWaitApproval(userName.Id);
            return View(reservationList);
        }
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in _destinationService.TGetList()
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
            _reservationService.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}
