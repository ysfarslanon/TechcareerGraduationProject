using Entities.Dtos.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.CategoryValidators
{
    public class CategoryAddDtoValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddDtoValidator()
        {
            RuleFor(p=>p.Name).NotEmpty().MinimumLength(2).WithMessage("Kategori ismi en az 2 karakter olmalıdır.");
        }
    }
}
