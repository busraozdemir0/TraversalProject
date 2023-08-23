using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.Comment
{
    public class _AddComment:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
