using Entities.Dtos.ShoppingLists;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ShoppingListValidators
{
    public class ShoppingListUpdateDtoValidator : AbstractValidator<ShoppingListUpdateDto>
    {
        public ShoppingListUpdateDtoValidator()
        {
            RuleFor(p=>p.Id).NotNull().NotEmpty();
            RuleFor(p=>p.UserId).NotEmpty().NotNull();
            RuleFor(p=>p.Name).NotEmpty().MinimumLength(2);
            RuleFor(p=>p.IsShopping).NotNull();
        }
    }
}
