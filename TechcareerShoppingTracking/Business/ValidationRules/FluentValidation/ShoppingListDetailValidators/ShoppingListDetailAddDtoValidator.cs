using Entities.Dtos.ShoppingListDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ShoppingListDetailValidators
{
    public class ShoppingListDetailAddDtoValidator : AbstractValidator<ShoppingListDetailAddDto>
    {
        public ShoppingListDetailAddDtoValidator()
        {
            RuleFor(p => p.ShoppingListId).NotEmpty().NotNull();
            RuleFor(p => p.ProductId).NotEmpty().NotNull();
            RuleFor(p => p.IsBought).NotNull();
        }
    }
}
