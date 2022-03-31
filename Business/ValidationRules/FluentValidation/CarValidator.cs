using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.dailyPrice).GreaterThan(0);
            RuleFor(c => c.Description.Length).GreaterThan(4);
            //RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(p => p.modelName).NotEmpty().WithMessage("Araba adı boş geçilmez...");
            RuleFor(p => p.modelName).MinimumLength(2);
            RuleFor(p => p.dailyPrice).NotEmpty();
            RuleFor(p => p.dailyPrice).GreaterThan(0);
            RuleFor(x => x.brandId).NotEmpty();
            RuleFor(x => x.colorId).NotEmpty();
            RuleFor(x => x.Findeks).NotEmpty();
            RuleFor(x => x.modelYear).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();



        }
    }
}
