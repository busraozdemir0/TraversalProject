using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin, Member, Manager, Editor , Visitor")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var context = new Context();
            var userName = User.Identity.Name;
            var userID = context.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var userComments = _commentService.TGetListUserComments(userID); // sisteme giren kullanıcının id'sine ait yorumlar listelenecek

            return View(userComments);
        }
        public IActionResult PasifComment(int id)
        {
            _commentService.TPasifTheComment(id);
            return RedirectToAction("Index");
        }
        public IActionResult ActiveComment(int id)
        {
            _commentService.TActiveTheComment(id);
            return RedirectToAction("Index");
        }
    }
}
