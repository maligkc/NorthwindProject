using FluentValidation;
using MvcWebUI.Models;

namespace MvcWebUI.ValidationRules.FluentValidation
{
    public class ShippingDetailValidator:AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("Adı Gereklidir");
            RuleFor(s => s.FirstName).MinimumLength(2); // kullanıcının ismi minimum 2 harften oluşmalı
            RuleFor(s => s.lastName).NotEmpty();
            RuleFor(s => s.adress).NotEmpty();
            RuleFor(s => s.city).NotEmpty(); // .When(s => s.age < 18); ile de kural koyulabilir

            //RuleFor(s => s.firstName).Must(StartWithA); // kendi kuralımızı uyduracağız
        }

        //private bool StartWithA(string args)
        //{
        //    return args.StartsWith("A");
        //}


    }
}
