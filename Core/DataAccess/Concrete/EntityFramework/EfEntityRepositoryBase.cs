using Core.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new() // TEntity bir referans tipi olmak zorunda ve newlenebilir olmalı
        where TContext : DbContext, new() // TContext ise DbContext inheritance'ı alacak ve newlenebilir olacak
        //burada yaptığımız işlem TEntity ve TContext'in yapısı konusunda uygulamayı sınırlıyoruz
        // yani programcı yanlış nesneleri buraya ekleyemeyecek 
    {

        //TContext : entity classlarımızla veritabanını bağdaştırdığımız
        //bir tasarım desenini implement eden hazır entity framework yapısıdır. 

        /*
        EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity, TContext> yapısı nedir?
        Benim EfEntityRepositoryBase ile çalışabilmem için TEntity ve TContext'e ihtiyacım var
        TEntity T gibi düşün Product Category Customer vs. veritabanı nesneleri
        TContext ise entity frameworkun bizden istediği entityframework altyapısı, 
        bunu kullanarak veritabanıyla bağlantıyı kuruyoruz
         */


        // burada yazdığımız add,delete,get,update veritabanı sorgularından sonra başka bir yerde yazmamıza gerek kalmayacak
        // mesela artık EfProductDal sınıfında public class EfProductDal : EfEntityRepositoryBase<Product, NorthWind> IProductDal
        // yazmamız yeterli olacaktır. EfProductDal sınıfı buradan direkt olarak add,delete,get,update komutlarını alabilecek

        public void Add(TEntity entity)
        {
            using(TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
