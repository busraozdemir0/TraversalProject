using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProject.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            Context context = new Context();
            ViewBag.commentCount = context.Comments.Where(x => x.DestinationID == id).Count();
            var values = commentManager.TGetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
