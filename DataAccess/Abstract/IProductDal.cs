using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
        Repository pattern: Sektörde kullanılan repository pattern, temel insert update delete seelct operasyonlarını 
        generic bir şekilde yazıp onu her yerde ortak bir şekilde kullanmamızı sağlayan bir sistem.
        Yani listeleme eklem silme güncelleme şeyini her sınıf için (product, category) tekrar tekrar yazmak yerine
        generic yapı sayesinde parametre yerine sadece product, customer, category yazarak bu işlemleri yapabiliriz.
        Aksi taktirde bizim her seferinde bu listeleme ekleme silme güncelleme komutlarını her seferinde yazmamız gerekir.
         */
//listeleme 
//ekleme
//silme
//güncelleme

// bunları buraya yazıp concrete katmanında bu interface'i implement edip işlemlerimizi daha kolay yapacağız



namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {

        // yukarıdaki implement işleminde aşağıdaki kodların geldiğini düşünebiliriz ama T yerinde Product olarak
        /*
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter = null);

        void Add(T entity); // veritabanına ekleme
        void Update(T entity); // veritabanında güncelleme
        void Delete(T entity); // veritabanından silme 
         */




    }
}
