using Entities.Dtos.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.CategoryValidators
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(p=>p.Id).NotEmpty().NotEmpty();
            RuleFor(p=>p.Name).NotEmpty().NotEmpty().MinimumLength(2);
        }
    }
}
