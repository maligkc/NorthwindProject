using Entities.DomainModels;

namespace MvcWebUI.Helpers
{
    public interface ISepetSessionHelper
    {
        Sepet GetSepet(string key);
        void SetSepet(string key, Sepet sepet);
        void Clear();
    }
}
