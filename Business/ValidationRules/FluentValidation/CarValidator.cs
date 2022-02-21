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



        }
    }
}
