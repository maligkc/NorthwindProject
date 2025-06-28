using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DomainModels
{
    public class Sepet:IDomainModel
    {
        public Sepet()
        {
            SepetUrunDetaylari = new List<SepetUrunDetayi>();
        }
        public List<SepetUrunDetayi> SepetUrunDetaylari { get; set; }

        //public decimal sepetToplam
        //{
        //    get { return SepetUrunDetaylari.Sum(c => c.urunSayisi * c.Product.UnitPrice); }
        //}
    }
}
