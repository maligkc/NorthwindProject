using Bussines.Abstract;
using Entities.Concrete;
using Entities.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class SepetManager : ISepetService
    {
        public void sepeteEkle(Sepet sepet, Product product)
        {
            // gönderdiğimiz id'de başka bir ürün var mı kontrol et
            SepetUrunDetayi sepetUrunDetayi = sepet.SepetUrunDetaylari.FirstOrDefault(s => s.Product.ProductID == product.ProductID);
            // .FirstOrDefault(...): Şartı sağlayan ilk elemanı bulur. Eğer yoksa null döner.
            //s => s.Product.ProductID==product.ProductID: Lambda ifadesi — listedeki her s elemanı için ProductID eşit mi diye bakar.



            if (sepetUrunDetayi != null)
            {
                // sepette ürün var demektir
                sepetUrunDetayi.urunSayisi++;
                return;
            }
            else
            {
                sepet.SepetUrunDetaylari.Add(new SepetUrunDetayi { Product = product, urunSayisi = 1 });
                // boş sepete urun ekledik ve sepetteki ürün sayısını 1 yaptık
            }
        }

        public List<SepetUrunDetayi> sepetiGoruntule(Sepet sepet)
        {
            return sepet.SepetUrunDetaylari;
        }

        public void sepettenCikar(Sepet sepet, int productId)
        {
            sepet.SepetUrunDetaylari.Remove(sepet.SepetUrunDetaylari.FirstOrDefault(s => s.Product.ProductID == productId));
        }
    }
}
