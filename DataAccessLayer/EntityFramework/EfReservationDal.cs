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
                return context.Reservations.Include(x => x.Destination).Where(y => y.Status == "Geçmiş Rezervasyon" && y.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            using (var context = new Context())
            {
                // Rezervasyon tablosuna Destination'u dahil edelim (Destination.City yazdığımızda ulaşabilmek için)
                return context.Reservations.Include(x => x.Destination).Where(y => y.Status == "Onay Bekliyor" && y.AppUserId==id).ToList();
            }
        }
    }
}
