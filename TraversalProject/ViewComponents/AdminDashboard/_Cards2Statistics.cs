using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProject.ViewComponents.AdminDashboard
{
    public class _Cards2Statistics:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using(var context=new Context())
            {
                ViewBag.totalComment = context.Comments.Count();
                ViewBag.totalMessages = context.ContactUses.Count();
            }
            return View();
        }
    }
}
