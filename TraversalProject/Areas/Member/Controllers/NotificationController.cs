using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin,Member, Manager, Editor , Visitor")]
    public class NotificationController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public NotificationController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var announcements = _announcementService.TGetList();
            ViewBag.announcementCount=announcements.Count;
            return View(announcements);
        }
        public IActionResult Details(int id)
        {
            var announcementValue = _announcementService.TGetByID(id);
            return View(announcementValue);
        }
    }
}
