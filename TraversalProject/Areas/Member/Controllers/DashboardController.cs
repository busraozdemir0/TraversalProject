﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalProject.Areas.Member.Controllers
{
    [Area("Member")]
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
    }
}