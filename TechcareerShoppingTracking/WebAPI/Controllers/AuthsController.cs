using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Entities.Dtos.Auths;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public ActionResult<AccessToken> Register(UserRegisterDto userRegisterDto)
        {
            var result = _authService.Register(userRegisterDto);
            if (result is null)
            {
                return BadRequest(result);
            }
            UserLoginDto createdUserLoginDto = new() { Email = userRegisterDto.Email, Password = userRegisterDto.Password };

            var loginResult = _authService.Login(createdUserLoginDto);
            return Created("", loginResult);
        }

        [HttpPost("Login")]
        public ActionResult<AccessToken> Login(UserLoginDto userLoginDto)
        {
            var result = _authService.Login(userLoginDto);
            
            return Ok(result);
        }

      
    }

   
}
