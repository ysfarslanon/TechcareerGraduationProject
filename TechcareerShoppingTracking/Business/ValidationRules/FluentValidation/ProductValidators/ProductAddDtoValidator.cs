using Entities.Dtos.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ProductValidators
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty().NotNull();
            RuleFor(p => p.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(p => p.PictureURL).NotEmpty().NotNull();
        }
    }
}
