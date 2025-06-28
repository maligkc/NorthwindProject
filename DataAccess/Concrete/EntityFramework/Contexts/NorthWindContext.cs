using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthWindContext : DbContext
    { // burada bizim tablolarımızla entitylerimizi bağdaştırmamız gerekiyor
      // bunu da dbset dediğimiz tiple sağlıyoruz

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;initial catalog = Northwind;integrated security=true");
        }
         // Bu konfigürasyonla bağdaştırma yapılıyor



        public DbSet<Product> Products { get; set; }
        // Burada şunu söylüyoruz benim Product isminde bir tane nesnem var
        // onu veritabanındaki products ile map et (eşleştir, bağdaştır)

        public DbSet<Category> Categories { get; set; }

    }
}
