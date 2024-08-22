using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.BusinessLogic.Dtos;

namespace Tech.BusinessLogic.ValidationRules.FluentValidations
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name is not empty");
            RuleFor(x => x.Price).GreaterThan(10).LessThan(10000).WithMessage("Price must be between 10  and 100000");
            RuleFor(x => x.CategoryId).NotNull();

        }
    }
}
