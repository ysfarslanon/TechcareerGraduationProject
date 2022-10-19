using Entities.Dtos.Auths;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.AuthValidators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.Password).MinimumLength(8);
        }
    }
}
