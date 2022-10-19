using Entities.Dtos.ShoppingListDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ShoppingListDetailValidators
{
    public class ShoppingListDetailChangeIsBoughtDtoValidator : AbstractValidator<ShoppingListDetailChangeIsBoughtDto>
    {
        public ShoppingListDetailChangeIsBoughtDtoValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
            RuleFor(p => p.IsBought).NotNull();
        }
    }
}
