using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public void ActiveTheComment(int id)
        {
            using (var context = new Context())
            {
                var comment = context.Comments.Find(id);
                comment.CommentState = true;
                context.Comments.Update(comment);
                context.SaveChanges();
            }
        }

        public List<Comment> GetListCommentAndUser()
        {
            using (var context = new Context())
            {
                return context.Comments.Where(x=>x.CommentState==true).Include(x => x.AppUser).Include(x=>x.Destination).ToList();  
            }
        }

        public List<Comment> GetListCommentWithDestination()
        {
            using(var context=new Context())
            {
                return context.Comments.Where(x => x.CommentState == true).Include(x => x.Destination).ToList();  // Comment tablosuna Destinationu dahil et ki view tarafında birbirinin bilgilerine ulaşabilelim
            }
        }
        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            using (var context = new Context())
            {
                return context.Comments.Where(x=>x.DestinationID==id && x.CommentState==true).Include(x => x.AppUser).ToList(); 
            }
        }

        public List<Comment> GetListUserComments(int id)
        {
            using(var context=new Context())
            {
                return context.Comments.Where(x => x.AppUserID == id).Include(x => x.Destination).ToList();
            }
        }

        public void PasifTheComment(int id)
        {
            using (var context = new Context())
            {
                var comment = context.Comments.Find(id);
                comment.CommentState = false;
                context.Comments.Update(comment);
                context.SaveChanges();
            }
        }
    }
}
