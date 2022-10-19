using Entities.Dtos.ShoppingListDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ShoppingListDetailValidators
{
    public class ShoppingListDetailChangeDescriptionDtoValidator : AbstractValidator<ShoppingListDetailChangeDescriptionDto>
    {
        public ShoppingListDetailChangeDescriptionDtoValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
        }
    }
}
