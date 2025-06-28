using Entities.DomainModels;
using MvcWebUI.Extensions;

namespace MvcWebUI.Helpers
{
    public class SepetSessionHelper : ISepetSessionHelper
    {
        private IHttpContextAccessor httpContextAccessor;

        public SepetSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void Clear()
        {
            httpContextAccessor.HttpContext.Session.Clear();
        }

        public Sepet GetSepet(string key)
        {
            Sepet sepetToCheck = httpContextAccessor.HttpContext.Session.GetObject<Sepet>("sepet");
            // sessionda sepet var mı diye kontrol ediyoruz
            if (sepetToCheck == null) // eğer null gelirse sessionda sepet yok
            {
                
                SetSepet("sepet", new Sepet());// boş sepet oluşturuyoruz
                sepetToCheck = httpContextAccessor.HttpContext.Session.GetObject<Sepet>("sepet");
                // artık sepetimiz var onu returnleyecez
            }

            return sepetToCheck; // sessionda olan ama boş sepeti return ediyoruz
        }

        public void SetSepet(string key, Sepet sepet)
        {
            httpContextAccessor.HttpContext.Session.SetObject("sepet", sepet);
        }
    }
}
