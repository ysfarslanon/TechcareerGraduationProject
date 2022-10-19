using Entities.Dtos.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ProductValidators
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty();
            RuleFor(p => p.CategoryId).NotNull().NotEmpty();
            RuleFor(p => p.Name).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(p => p.PictureURL).NotNull().NotEmpty();
        }
    }
}
