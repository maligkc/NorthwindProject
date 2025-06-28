using Entities.Concrete;
using Entities.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface ISepetService
    {
        void sepeteEkle(Sepet sepet, Product product);
        void sepettenCikar(Sepet sepet, int productId);
        List<SepetUrunDetayi> sepetiGoruntule(Sepet sepet);
    }
}
