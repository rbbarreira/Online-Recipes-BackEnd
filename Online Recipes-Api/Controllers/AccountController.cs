using Microsoft.AspNetCore.Mvc;
using Online_Recipes_Domain.Account;
using Online_Recipes_Domain.DTOs;
using Online_Recipes_Service.Service_Interfaces;

namespace Online_Recipes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            // Check Email
            if (await _userService.EmailExist(user.Email))
            {
                return BadRequest(new { Message = "Email already exist!" });
            }

            //Check Username
            if (await _userService.UsernameExist(user.UserName))
            {
                return BadRequest(new { Message = "Username already exist!" });
            }

            var create = await _userService.Add(user);

            return Ok(create);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] Login login)
        {
            if (login == null)
            {
                return BadRequest();
            }

            var user = await _userService.GetUserByEmail(login.Email);

            if (user == null)
            {
                return NotFound(new { Message = "User not found!" });
            }

            var pass = await _userService.Authenticate(login.Email, login.Password);

            if (!pass)
            {
                return Unauthorized(new { Message = "User or password invalid!" });
            }

            var token = _userService.GenerateToken(user);

            return Ok(token);
        }
    }
}
