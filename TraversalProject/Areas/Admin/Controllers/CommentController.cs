using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var commentList = _commentService.TGetListCommentWithDestination();
            return View(commentList);
        }
        public IActionResult DeleteComment(int id)
        {
            var commentID = _commentService.TGetByID(id);
            _commentService.TDelete(commentID);
            return RedirectToAction("Index", "Comment", new {area="Admin"});
        }
    }
}
