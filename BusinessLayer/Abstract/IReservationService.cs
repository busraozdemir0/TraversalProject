using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    { 
        List<Reservation> TGetListWithReservationByWaitApproval(int id);
        List<Reservation> TGetListWithReservationByAccepted(int id);
        List<Reservation> TGetListWithReservationByPrevious(int id);
        List<Reservation> TGetListReservations();
        public void TApprovalReservations(int id);
    }
}
