using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    // Unit Of Work için ayrı bir generic interface
    public interface IGenericUowDal<T> where T: class
    {
        void Insert(T t);
        void Update(T t);
        void MultiUpdate(List<T> t); // aynı anda birden fazla kaydı güncelleyebilmek için
        T GetByID(int id); 
        

    }
}
