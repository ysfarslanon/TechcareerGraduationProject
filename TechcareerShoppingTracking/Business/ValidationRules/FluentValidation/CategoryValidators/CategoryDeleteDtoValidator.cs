using Entities.Dtos.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.CategoryValidators
{
    public class CategoryDeleteDtoValidator : AbstractValidator<CategoryDeleteDto>
    {
        public CategoryDeleteDtoValidator()
        {
            RuleFor(p=>p.Id).NotEmpty().NotNull();
        }
    }
}
