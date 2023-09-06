using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
