using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfFeatureDal : GenericRepository<Feature>, IFeatureDal
    {
        public List<Destination> FeaturedDestinations()
        {
            using(var context=new Context())
            {
                return context.Destinations.Where(x => x.Status.Equals(true)).Take(4).ToList();
            }
        }
    }
}
