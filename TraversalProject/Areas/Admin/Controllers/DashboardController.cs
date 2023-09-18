using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalProject.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Arama(string p)
        {
            Context context = new Context();
            var model = new AramaModel();
            model.AramaKey = p;

            if(!string.IsNullOrEmpty(p))
            {
                var about=context.Abouts.Where(x=>x.Title!.Contains(p) || "hakkımızda".Contains(p)).ToList();
                var member=context.Users.Where(x=>x.Name!.Contains(p) || "misafirler".Contains(p) || "üyeler".Contains(p)).ToList();
                var comment=context.Comments.Where(x=> "Yorum"!.Contains(p) || "yorumlar".Contains(p)).ToList();
                var destination=context.Destinations.Where(x=>x.City!.Contains(p) || "rotalar".Contains(p)).ToList();
                var contact=context.ContactUses.Where(x=>x.Subject!.Contains(p) || "mesajlar".Contains(p)).ToList();
                var reservation=context.Reservations.Where(x=> "Rezervasyonlar"!.Contains(p) || "rezervasyonlar".Contains(p)).Select(y=>"Rezervasyonlar").FirstOrDefault();
                var guide=context.Guides.Where(x=> "Rehberler"!.Contains(p) || "rehberler".Contains(p)).Select(y=>"Rehber Listesi").FirstOrDefault();
                var announcement=context.Announcements.Where(x=>x.Title!.Contains(p) || "duyurular".Contains(p)).FirstOrDefault();
                var newsletter=context.Newsletters.Where(x=>"Abone olanlar"!.Contains(p) || "abone olanlar".Contains(p)).FirstOrDefault();
                var approle=context.Roles.Where(x=>"Roller"!.Contains(p) || "roller".Contains(p)).FirstOrDefault();


                model.Abouts = about;
                model.Comments = comment;
                model.Destinations = destination;
                model.AppUsers = member;
                model.ContactUses = contact;
                ViewBag.Reservations = reservation;
                ViewBag.Guides = guide;
                ViewBag.Announcements = announcement;
                ViewBag.Newsletters = newsletter;
                ViewBag.AppRoles = approle;
            }
            return View(model);
            
        }
    }
}
