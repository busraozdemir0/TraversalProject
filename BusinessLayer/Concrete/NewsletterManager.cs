using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsletterManager : INewsletterService
    {
        INewsletterDal _newsletterDal;

        public NewsletterManager(INewsletterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void TAdd(Newsletter t)
        {
            _newsletterDal.Insert(t);
        }

        public void TDelete(Newsletter t)
        {
            _newsletterDal.Delete(t);
        }

        public Newsletter TGetByID(int id)
        {
            return _newsletterDal.GetByID(id);
        }

        public List<Newsletter> TGetList()
        {
            return _newsletterDal.GetList();
        }

        public void TUpdate(Newsletter t)
        {
            throw new NotImplementedException();
        }
    }
}
