using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal:IGenericDal<Destination>
    {
        public Destination GetDestinationWithGuide(int id);
        public List<Destination> GetLast4Destinations();
        public List<Destination> GetDestinationByReservation();
        public void DestinationIsPassive(Destination destination);
        public void DestinationIsActive(Destination destination);
        public int DestinationSearch(string cityName, DateTime date);
    }
}
