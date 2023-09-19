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
        public ContactUs ContactUsMessageDetails(int id)
        {
            using (var context = new Context())
            {
                var contactUs = context.ContactUses.Where(x => x.ContactUsID == id).FirstOrDefault();
                return contactUs;
            }
        }

        public void ContactUsStatusChangeToFalse(int id)
        {
            using (var context = new Context())
            {
                var contactUs = context.ContactUses.Where(x => x.ContactUsID == id).FirstOrDefault();
                contactUs.MessageStatus = false;
                context.ContactUses.Update(contactUs);
                context.SaveChanges();
            }
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            using (var context = new Context())
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
