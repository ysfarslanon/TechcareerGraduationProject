using Business.Abstract;
using Business.ValidationRules.FluentValidation.AuthValidators;
using Core.Helpers.HashingHelper;
using Entities.Concrete;
using Entities.Dtos.Auths;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthManager(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        public AccessToken Login(UserLoginDto userLoginDto)
        {
            UserLoginDtoValidator validationRules = new UserLoginDtoValidator();
            var validResult = validationRules.Validate(userLoginDto);

            if (!validResult.IsValid) return null;

            var user = _userService.GetByEmail(userLoginDto.Email);

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return CreateToken(user);
        }

        public User Register(UserRegisterDto userRegisterDto)
        {
            UserRegisterDtoValidator validationRules = new UserRegisterDtoValidator();
            var validResult = validationRules.Validate(userRegisterDto);

            if (!validResult.IsValid) return null;

            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User newUser = new User();
            newUser.FirstName = userRegisterDto.FirstName;
            newUser.LastName = userRegisterDto.LastName;
            newUser.Email = userRegisterDto.Email;
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            var result = _userService.Add(newUser);

            if (!result) return null;

            return newUser;
        }

        public AccessToken CreateToken(User user)
        {

            List<Claim> claims = new List<Claim>()
            {
                new Claim("id", $"{user.Id}"),
                new Claim("fullName", $"{user.FirstName} {user.LastName}"),
                new Claim("role", _userService.GetUserRole(user.Id))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("TokenOptions:SecretKey").Value
                ));

            var signingCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new AccessToken { Token = jwt };
        }

        // ------------- BUSINESS RULES -------------

    }
}
