using Entities.Dtos.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ProductValidators
{
    public class ProductDeleteDtoValidator : AbstractValidator<ProductDeleteDto>
    {
        public ProductDeleteDtoValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
        }
    }
}
