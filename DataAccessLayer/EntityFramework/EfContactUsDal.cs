using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ContactUsStatusChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            using(var context=new Context())
            {
                //MessageStatus'u false olan mesajlar listelenecek
                var falseValues = context.ContactUses.Where(x => x.MessageStatus == false).ToList();
                return falseValues;
            }
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            using (var context = new Context())
            {
                var trueValues = context.ContactUses.Where(x => x.MessageStatus == true).ToList();
                return trueValues;
            }
        }
    }
}
