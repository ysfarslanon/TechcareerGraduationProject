using Entities.Dtos.ShoppingLists;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ShoppingListValidators
{
    public class ShoppingListChangeIsShoppingDtoValidator : AbstractValidator<ShoppingListChangeIsShoppingDto>
    {
        public ShoppingListChangeIsShoppingDtoValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
            RuleFor(p=>p.IsShopping).NotNull();
        }
    }
}
