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
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public void ApprovalReservations(int id)
        {
            using (var context = new Context())
            {
                var value = context.Reservations.Find(id);
                value.Status = "Onaylandı";
                context.Reservations.Update(value);
                context.SaveChanges();
            }
        }

        public List<Reservation> GetListReservations()
        {
            using (var context = new Context())
            {
                // Rezervasyon tablosuna Destination'u ve User tablosunu dahil edelim (Destination.City yazdığımızda ulaşabilmek için)
                return context.Reservations.Include(x => x.Destination).Include(x => x.AppUser).Where(y => y.Status == "Onay Bekliyor" || y.Status=="Onaylandı").ToList();
            }
        }

        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                // Rezervasyon tablosuna Destination'u dahil edelim (Destination.City yazdığımızda ulaşabilmek için)
                return context.Reservations.Include(x => x.Destination).Where(y => y.Status == "Onaylandı" && y.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                // Rezervasyon tablosuna Destination'u dahil edelim (Destination.City yazdığımızda ulaşabilmek için)
                var value = context.Reservations.Include(x => x.Destination).Where(y => y.ReservationDate < DateTime.Now && y.AppUserId == id).ToList();
                foreach (var item in value) // Eğer rezervasyon tarihi bugünün tarihinden küçükse Durumunu Geçmiş Rezervasyon olarak güncelleyecek.
                {
                    item.Status = "Geçmiş Rezervasyon";
                    context.Reservations.Update(item);
                }
                context.SaveChanges();
                return value;
            }
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            using (var context = new Context())
            {
                // Rezervasyon tablosuna Destination'u ve User tablosunu dahil edelim (Destination.City yazdığımızda ulaşabilmek için)
                return context.Reservations.Include(x => x.Destination).Include(x => x.AppUser).Where(y => y.Status == "Onay Bekliyor" && y.AppUserId == id).ToList();
            }
        }
    }
}
