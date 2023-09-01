using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TraversalProject.CQRS.Results.DestinationResults;

namespace TraversalProject.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x=> new GetAllDestinationQueryResult
            {
                id=x.DestinationID,
                city = x.City,
                capacity =x.Capacity,
                daynight=x.DayNight,
                price=x.Price
            }).AsNoTracking().ToList();  // EF'de varsayılan olarak yapılan değişiklikler izlenir durumdadır. AsNoTracking kullanıldığında Entity üzerinde değişiklik var mı yok mu diye izlenmez.
            return values;
        }
    }
}
