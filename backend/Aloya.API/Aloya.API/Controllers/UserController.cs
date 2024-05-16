using Aloya.Core;
using Aloya.Core.Auth;
using Aloya.Core.Interfaces;
using Aloya.Core.Services;
using Aloya.Transfer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Aloya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        private readonly IUserService _userService;
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IResult> Register([FromForm] string username, [FromForm] string password, [FromForm] string email)
        {
            var result = await _userService.Register(username, email, password);
            if (!result)
            {
                return Results.BadRequest(result);
            }
            else
            {
                await Login(email, password);
                return Results.Ok(result);
            }
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<UserDTO> Login([FromForm] string email, [FromForm] string password)
        {
            var (token, userDTO) = await _userService.Login(email, password);
            if (token.Contains("incorrect") || token.Contains("failed"))
            {
                return null;
            }
            else
            {
                Response.Cookies.Append("mar-cookies", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None

                });
                return userDTO;
            }
        }
        [Authorize(Policy = "StudentPolicy")]
        [HttpPut("verify")]
        public async Task<IResult> Verify([FromForm] string phone)
        {
            var result = await _userService.Verify(AuthProvider.GetCurrentId(User), phone);
            if (!result)
            {
                return Results.BadRequest(result);
            }
            else
            {
                return Results.Ok(result);
            }
        }
        [Authorize(Policy = "StudentPolicy")]
        [HttpPut("userUpdate")]
        public async Task<IResult> UserChange([FromForm] string avatar, [FromForm] string username, [FromForm] string firstname, [FromForm] string lastname)
        {

            var result = await _userService.ChangeUser(AuthProvider.GetCurrentId(User), ByteConverter.GetBytes(avatar), username, firstname, lastname);
            return Results.Ok(result);
        }
        [Authorize(Policy = "StudentPolicy")]
        [HttpPut("PasswordChange")]
        public async Task<IResult> PasswordChange([FromForm] string password,[FromForm] string confirm)
        {
            var result = await _userService.ChangePassword(AuthProvider.GetCurrentId(User), password,confirm);
            if (!result)
            {
                return Results.BadRequest(result);
            }
            else 
            {
                return Results.Ok(result);
            }
        }
    }
}
