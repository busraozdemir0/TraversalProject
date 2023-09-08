using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal:IGenericDal<Comment>
    {
        public List<Comment> GetListCommentWithDestination();
        public List<Comment> GetListCommentWithDestinationAndUser(int id);
        public List<Comment> GetListCommentAndUser();
        public List<Comment> GetListUserComments(int id);   // giriş yapan kullanıcının yorumları

        void PasifTheComment(int id);
        void ActiveTheComment(int id);
    }
}
