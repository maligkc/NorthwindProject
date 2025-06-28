using System.ComponentModel.DataAnnotations;

namespace MvcWebUI.Models
{
    public class ShippingDetail
    {
        //[Required(ErrorMessage ="İsim boş bırakılamaz")]
        public string FirstName { get; set; }

        //[Required]
        public string lastName { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        public string email { get; set; }

        //[Required]
        public string city { get; set; }

        //[Required]
        //[MinLength(10,ErrorMessage ="Minimum 10 karakter olmalıdır.")]
        public string adress { get; set; }

        //[Required]
        //[Range(18,65)]
        public string age { get; set; }
    }
}
