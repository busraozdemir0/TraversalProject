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
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public void DestinationIsActive(Destination destination)
        {
            using (var context = new Context())
            {
                destination.Status = true;
                context.Destinations.Update(destination);
                context.SaveChanges();
            }
        }

        public void DestinationIsPassive(Destination destination)
        {
            using (var context = new Context())
            {
                destination.Status = false;
                context.Destinations.Update(destination);
                context.SaveChanges();
            }
        }

        public int DestinationSearch(string cityName, DateTime date)
        {
            using (var context = new Context())
            {
                var id= context.Destinations  
                    .Where(x => x.City
                    .Equals(cityName) && x.Date.Equals(date))
                    .Select(y=>y.DestinationID)
                    .FirstOrDefault();

                if (id != 0)
                    return id;

                else
                    return 0; // eğer belirtilen kriterlerde rota yoksa 1 numaralı id'li rotayı döndürsün
                
            }
        }

        public List<Destination> GetDestinationByReservation()
        {
            using (var context = new Context())
            {
                return context.Destinations.Include(x => x.Reservations).ToList();
            }
        }

        public Destination GetDestinationWithGuide(int id)
        {
            using(var context=new Context())
            {
                return context.Destinations.Where(y=>y.DestinationID==id).Include(x => x.Guide).FirstOrDefault(); // gelen id bilgisiyle DestinationID bilgisi eşit olanlara Guide tablosunu dahil et
            }
        }

        public List<Destination> GetLast4Destinations()
        {
            using (var context = new Context())
            {
                var destinations = context.Destinations.Take(4).OrderByDescending(x => x.DestinationID).ToList();  // azalan bir şekilde sıralayıp ilk 4 destinationu alıyoruz
                return destinations;
            }
        }
    }
}
