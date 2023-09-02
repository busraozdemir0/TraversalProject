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
    public class EfAccountDal:GenericUowRepository<Account>, IAccountDal
    {
        public EfAccountDal(Context context):base(context)  // GenericUowRepository'de dependency injection yaptığımız için burada da enjekte etmemiz gerekiyor.
                                                            // base(context) diyerek tanımlanan Context'i burada da gönderdik
        {

        }
    }
}
