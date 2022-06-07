using System;
using System.Threading.Tasks;
using jwt_authentication_boilerplate.Data.DTO;
using jwt_authentication_boilerplate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace jwt_authentication_boilerplate.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost, Route("login")]
        public async Task<ActionResult<JwtResultDTO>> Login(AuthUserDTO authUserDTO)
        {
            try
            {

                if (authUserDTO.Mail != null && authUserDTO.Password != null)
                {
                    JwtResultDTO jwtResultDto = await _authService.Authentication(authUserDTO);
                    if (jwtResultDto != null)
                    {
                        return Ok(jwtResultDto);
                    }
                    else return BadRequest("email or password is not correct");

                }

                return BadRequest("one or more fields is empty");

            }
            catch (Exception)
            {
                return BadRequest("Erorr server");
            }

        }
    }
}
