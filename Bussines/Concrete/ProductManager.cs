using Bussines.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class ProductManager : IProductService
    {
        // EfProductDal'ı kullanacağız ama new'lemeden.
        // Eğer burada EfProductDal'ı newlersek yarın öbürgün
        // entity frameworkten vazgeçtiğimizde problem yaşayacağız

        //Entity frameworke dair burada hiçbir şey olmamalı.
        private IProductDal _productDal; // EfProductDal'ın interface'i IProductDal olduğu için onu kullanıyoruz.

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            

            return _productDal.GetList();

        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p=>p.CategoryID == categoryId);
            //p=>p.CategoryID == categoryId ifadesi
            // p Product tablosunda her bir satırı ifade eder
            // p.CategoryId == categoryId veritabanındaki Product tablosundan categoryId ile
            // fonksiyona verilen categoryId ile eşleşen verileri getir anlamına gelir
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductID == productId);
        }
    }
}
