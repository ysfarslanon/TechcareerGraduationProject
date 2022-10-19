using Entities.Dtos.ShoppingLists;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ShoppingListValidators
{
    public class ShoppingListDeleteDtoValidator : AbstractValidator<ShoppingListDeleteDto>
    {
        public ShoppingListDeleteDtoValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty();
        }
    }
}
