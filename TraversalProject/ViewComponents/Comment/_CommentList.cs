using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProject.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            Context context = new Context();
            ViewBag.commentCount = context.Comments.Where(x => x.DestinationID == id && x.CommentState==true).Count();
            var values = _commentService.TGetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
