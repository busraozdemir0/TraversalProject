using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var reservations=_reservationService.TGetListReservations();
            return View(reservations);
        }
        public IActionResult ApprovalReservation(int id)
        {
            _reservationService.TApprovalReservations(id);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteReservation(int id)
        {
            var value = _reservationService.TGetByID(id);
            _reservationService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
