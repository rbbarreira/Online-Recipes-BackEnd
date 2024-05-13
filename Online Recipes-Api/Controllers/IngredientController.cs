using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Recipes_Domain.Account;
using Online_Recipes_Domain.Models;
using Online_Recipes_Service.Service_Interfaces;

namespace Online_Recipes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        [Route("List Ingredient")]
        public async Task<ActionResult<List<Ingredient>>> GetIngredients()
        {
            var ingredient = await _ingredientService.GetAll();

            return Ok(ingredient);
        }

        [HttpGet]
        [Route("Search By {id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ingredient = await _ingredientService.GetById(id);

            if (ingredient == null)
            {
                return NotFound("Id not found!");
            }

            return Ok(ingredient);
        }

        [HttpPost]
        [Route("Create Ingredient")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Add(Ingredient ingredient)
        {
            var exist = await _ingredientService.Add(ingredient);

            if (exist == null)
            {
                return BadRequest("Error occour while creating!");
            }

            return Ok(new { Result = "Success", Message = "Create successfully" });
        }

        [HttpPut]
        [Route("Update Ingredient")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update(Ingredient ingredient)
        {
            var exist = await _ingredientService.Update(ingredient);

            if (exist == null)
            {
                return BadRequest("Error occour while updating!");
            }

            return Ok(new { Result = "Success", Message = "Update successfully" });
        }

        [HttpDelete]
        [Route("Delete By {id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> RemoveById(int id)
        {
            var exist = await _ingredientService.GetById(id);

            if (exist == null)
            {
                return NotFound("Id not found!");
            }

            await _ingredientService.RemoveById(id);

            return Ok(new { Result = "Success", Message = "Delete successfully" });
        }
    }
}
