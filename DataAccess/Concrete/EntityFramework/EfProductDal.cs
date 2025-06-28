using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;




namespace DataAccess.Concrete.EntityFramework
{
    // EfProductDal = EntityFramework Data Access Layer

    /* İMPLEMENT SIRASI */
    // EfProductDal < EfEntityRepositoryBase<TContext, TContext> < IEntityRepository<T>
    // EfProductDal < IProductDal
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthWindContext>, IProductDal
 //Bunu yaptığımız an Product ile ilgili bütün insert update delete sorguları hazır burada kullanabiliriz demek oluyor
    {
        //Yarın öbür gün ben Customer sınıfını eklemek istediğimde Entity katmanına gidip Concrete klasöründe bir
        //Customer.cs oluşturacağım sonra da (hiç Core katmanına bulaşmadan) DataAccess katmanına gelip
        //EntityFramework klasöründe EfCustomerDal oluşturacağım ve implement kısmına
        //EfEntityRepository<Customer, NorthWindContext>, ICustomerDal yazmamız yeterli olacaktır.
        // Buradan anladığımız EfEntityRepository interfacesini Core katmanına bir defa yazıp istediğimiz sınıfımızda kullanabiliyoruz.

    }
}
