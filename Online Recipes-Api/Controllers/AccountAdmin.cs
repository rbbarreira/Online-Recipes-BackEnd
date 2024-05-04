using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Recipes_Domain.Account;
using Online_Recipes_Service.Service_Interfaces;

namespace Online_Recipes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAdmin : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountAdmin(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("List Users - Admin")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var user = await _userService.GetAll();

            return Ok(user);
        }

        [HttpGet]
        [Route("Search By {id} - Admin")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound("Id not found!");
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("Update Role - Admin")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update(string role, User user)
        {
            if (user.Id == null)
            {
                return NotFound("Id not found!");
            }
            else
            {
                user.Role = role;
                await _userService.Update(user);
                return Ok("Update successfully");
            }
        }

        [HttpDelete]
        [Route("Delete By {id} - Admin")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> RemoveById(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound("Id not found!");
            }

            await _userService.RemoveById(id);

            return Ok("Delete successfully");
        }
    }
}
