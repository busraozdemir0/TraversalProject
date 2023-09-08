using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalProject.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationService _destinationService;

        public DestinationController(UserManager<AppUser> userManager, IDestinationService destinationService)
        {
            _userManager = userManager;
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.ID = id;
            if (User.Identity.IsAuthenticated)
            {
                var userName = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.userID = userName.Id; // sisteme giriş yapan kullanıcının id'si
            }
            else
            {
                ViewBag.commentMessage = "Yorum yapabilmek için sisteme üye olmanız gerekmektedir!";
            }
            var values = _destinationService.TGetDestinationWithGuide(id);
            return View(values);
        }
    }
}
