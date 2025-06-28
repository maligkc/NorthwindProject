using Bussines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MvcWebUI.Models;

namespace MvcWebUI.ViewComponents
{
    // ViewComponent'in isimlendirme standardı = sonuna ViewComponent yazmak
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        { // Controllerdaki IActionResult Index()'in içindekinin aynısı 

            var model = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"]) 
                // /product/index?category=@category.CategoryID category değerini alacak
            };

            return View(model);





            // View'ını default olarak Shared klasörünün içinde Components klasöründe arıyor
            // Bunun için Shared klasörünün içine bir Components klasörü oluşturmalıyız
            // Kategoriler üzerinde çalıştığımız için Components klasörünün içine CategoryList klasörü oluşturuyoruz
            // Buradaki .cshtml dosyasının ismi Default.cshtml olmalı.
            // Category klasöründeki Index.cshtml dosyasının ismini
            // Default.cshtml yaparak CategoryList klasörüne taşıyoruz
            // Bunu yapınca CategoryController'da IActionResult'lu koda ihtiyaç yok.
            // CategoryController'ı daha sonra yeni bir kategori eklemek güncellemek vs için kullanabiliriz
        }
    }
}
