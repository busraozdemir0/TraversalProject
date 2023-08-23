using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
