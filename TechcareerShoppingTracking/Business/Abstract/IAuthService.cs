using Business.Concrete;
using Entities.Concrete;
using Entities.Dtos.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        User Register(UserRegisterDto registerUserDto);
        AccessToken Login(UserLoginDto userLoginDto);
    }
}