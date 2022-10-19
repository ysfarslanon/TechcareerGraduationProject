using Entities.Dtos.Auths;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.AuthValidators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır.");
            RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır.");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Email adresi girmelisiniz");
            RuleFor(p => p.Password).Equal(a => a.PasswordRepeat).WithMessage("Şifre ve şifre tekrarı aynı olmalıdır.");
            RuleFor(p => p.Password)
                   .MinimumLength(8).WithMessage("Şifre en az 8 karakter içermelidir.")
                   .Matches(@"[A-Z]+").WithMessage("Şifre en az bir tane büyük harf içermelidir.")
                   .Matches(@"[a-z]+").WithMessage("Şifre en az bir tane küçük harf içermelidir.")
                   .Matches(@"[0-9]+").WithMessage("Şifre en az bir tane rakam içermelidir.");
        }
    }
}
