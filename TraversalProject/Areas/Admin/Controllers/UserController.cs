using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var userList = _appUserService.TGetList();
            
            return View(userList);
        }
        public IActionResult DeleteUser(int id)
        {
            var userID = _appUserService.TGetByID(id);
            _appUserService.TDelete(userID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var userID = _appUserService.TGetByID(id);
            return View(userID);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser user)
        {
            _appUserService.TUpdate(user);
            return RedirectToAction("Index");
        }
        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }
        public IActionResult ReservationUser(int id)
        {
            var reservations= _reservationService.GetListWithReservationByAccepted(id); // reservation onaylananların listesi
            return View(reservations);
        }
    }
}
