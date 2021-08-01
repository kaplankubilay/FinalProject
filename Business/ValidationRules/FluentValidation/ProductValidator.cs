using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        /// <summary>
        /// validation kuralları ctor içerisine yazılır. Validation rules have to writes in the constructor.
        /// </summary>
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            //categoryId 1 ise 10 dan büyük olmalıdır. 
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 1);

            //olmayan bir kuralı kendimiz tanımlayabiliriz. Ayrıca withmessage ile kendi hatamızın açıklamasını yapabiliriz.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Urun a ile baslamali...");
        }

        /// <summary>
        /// startswith .net in string fonksiyonlarından.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
