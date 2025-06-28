using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter = null);

        void Add(T entity); // veritabanına ekleme
        void Update(T entity); // veritabanında güncelleme
        void Delete(T entity); // veritabanından silme

    }
}
