using Entities.Dtos.ShoppingListDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ShoppingListDetailValidators
{
    public class ShoppingListDetailDeleteDtoValidator : AbstractValidator<ShoppingListDetailDeleteDto>
    {
        public ShoppingListDetailDeleteDtoValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty();
        }
    }
}
