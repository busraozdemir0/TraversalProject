using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        public Destination TGetDestinationWithGuide(int id);
        public List<Destination> TGetLast4Destinations();
        public List<Destination> TGetDestinationByReservation();
        public void TDestinationIsPassive(Destination destination);
        public void TDestinationIsActive(Destination destination);
        public int TDestinationSearch(string cityName, DateTime date);
    }
}
