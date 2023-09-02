using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    // Unit Of Work için ayrı bir generic repository
    public class GenericUowRepository<T> : IGenericUowDal<T> where T : class
    {
        private readonly Context _context;

        public GenericUowRepository(Context context)
        {
            _context = context;
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            _context.Add(t);
            // kaydetme işlemi ayrı bir metod içerisinde yazılmalı(unit of work yapısına göre)
        }

        public void MultiUpdate(List<T> t)
        {
            _context.UpdateRange(t); // aynı anda birden fazla değere göre güncelleme
        }

        public void Update(T t)
        {
            _context.Update(t);
        }
    }
}
