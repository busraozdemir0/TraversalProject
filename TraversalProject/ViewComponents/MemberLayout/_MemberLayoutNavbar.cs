using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
