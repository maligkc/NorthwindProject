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
// implement sırasına göre çalışma mantığı
// EfCategoryDal > ICategory interface'i > IEntityRepository<Category> interface'i

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthWindContext>, ICategoryDal
    //Bunu yaptığımız an Category ile ilgili bütün insert update delete sorguları hazır demek oluyor
    //Yarın öbür gün ben Customer sınıfını eklemek istediğimde Entity katmanına gidip Concrete klasöründe bir
    //Customer.cs oluşturacağım sonra da (hiç Core katmanına bulaşmadan) DataAccess katmanına gelip
    //EntityFramework klasöründe EfCustomerDal oluşturacağım ve implement kısmına
    //EfEntityRepository<Customer, NorthWindContext>, ICustomerDal yazmamız yeterli olacaktır.
    // Buradan anladığımız EfEntityRepository interfacesini Core katmanına bir defa yazıp istediğimiz sınıfımızda kullanabiliyoruz.

    {

    }
}
