using Bussines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class ProductController:Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        

        public IActionResult Index(int category) // int category query stringde okumak için (Views içinde)
        {
            // return View(_productService.GetAll()); yazacağımıza encapsulation kullanıyoruz 
            // Models içindeki ProductListViewModel classını kullanıyoruz.


            var model = new ProductListViewModel
            {
                Products = category > 0 ? _productService.GetByCategory(category):_productService.GetAll()
                // category > 0 ? --> category > 0 mı
                // büyükse _productService.GetByCategory(category) çalıştır
                // değilse _productService.GetAll() çalıştır
            };

            // ProductListViewModel içinde public List<Product> Products { get; set; } olduğu için
            // yukardaki kodda Products list'inin içine geldi bütün veriler onu da model'e eşitledik


            ViewBag.CurrentCategoryId = category;
            // eğer kategoriler sayfasında sepete eklendiyse aynı sayfada kalmasını sağlıyor


            // içinde veriler liste halinde tutulan modeli de burada returnladık
            return View(model);

            // sadece böyle yaparsak depency injection hatası alırız 
            // onun için Start
        }
    }
}
