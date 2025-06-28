using Bussines.Abstract;
using Entities.Concrete;
using Entities.DomainModels;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class SepetController:Controller
    {
        private ISepetService sepetService;
        private ISepetSessionHelper sepetSessionHelper;
        private IProductService productService;

        public SepetController(ISepetService sepetService, ISepetSessionHelper sepetSessionHelper, IProductService productService)
        {
            this.sepetService = sepetService;
            this.sepetSessionHelper = sepetSessionHelper;
            this.productService = productService;
        }

        public IActionResult SepeteEkle(int productId, int? categoryId)
        {
            // ürünü veritabanından çekme işi
            Product product = productService.GetById(productId);

            var sepet = sepetSessionHelper.GetSepet("sepet");

            sepetService.sepeteEkle(sepet, product);
            sepetSessionHelper.SetSepet("sepet", sepet);

            TempData.Add("message", product.ProductName + " sepete eklendi!");
            // kullanıcıyı bilgilendirmek

            if (categoryId.HasValue)
            {
                return RedirectToAction("Index", "Product", new {category = categoryId.Value});
            }

            return RedirectToAction("Index", "Product");

        }

        public IActionResult SepettenCikar(int productId)
        {
            // ürünü çekiyoruz
            Product product = productService.GetById(productId);
            var sepet = sepetSessionHelper.GetSepet("sepet");
            
            sepetService.sepettenCikar(sepet, productId);

            sepetSessionHelper.SetSepet("sepet", sepet);

            TempData.Add("message", product.ProductName + " sepetten çıkarıldı!");

            return RedirectToAction("Index", "Sepet");
        }

        public IActionResult Index()
        {
            var model = new SepetListViewModel
            {
                Sepet = sepetSessionHelper.GetSepet("sepet")
            };

            return View(model);
        }

        // httpget
        public IActionResult Complete()
        {
            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail()
            };

            return View();
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if (!ModelState.IsValid)
            {
                //Eğer formdaki alanlar DataAnnotation ([Required], [StringLength] vs.)
                //kurallarına uymuyorsa (yani geçersizse):
                // Sayfa aynı şekilde tekrar gösterilir.
                return View();
            }


            TempData.Add("message", "Siparişiniz başarıyla tamamlandı");

            sepetSessionHelper.Clear();
            return RedirectToAction("Index", "Sepet");
        }

    }
}
