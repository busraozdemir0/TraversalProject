using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        List<Comment> TGetDestinationById(int id);
        List<Comment> TGetListCommentWithDestination();
        public List<Comment> TGetListCommentAndUser();
        public List<Comment> TGetListCommentWithDestinationAndUser(int id);
        public List<Comment> TGetListUserComments(int id);
        void TPasifTheComment(int id);
        void TActiveTheComment(int id);
    }
}
