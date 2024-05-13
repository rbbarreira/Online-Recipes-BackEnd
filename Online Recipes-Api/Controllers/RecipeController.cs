using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Recipes_Domain.Account;
using Online_Recipes_Domain.Models;
using Online_Recipes_Service.Service_Interfaces;

namespace Online_Recipes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("List Recipes")]
        public async Task<ActionResult<List<Recipe>>> GetRecipes()
        {
            var recipe = await _recipeService.GetAll();

            return Ok(recipe);
        }

        [HttpGet]
        [Route("Search By {id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recipe = await _recipeService.GetById(id);

            if (recipe == null)
            {
                return NotFound("Id not found!");
            }

            return Ok(recipe);
        }

        [HttpPost]
        [Route("Create Recipe")]
        //[Authorize(Roles = Role.Admin + "," + Role.User)]
        public async Task<IActionResult> Add(Recipe recipe)
        {
            if (recipe == null)
            {
                return BadRequest("Error occour while creating!");
            }

            await _recipeService.Add(recipe);

            return Ok(new { Result = "Success", Message = "Create successfully" });            
        }

        [HttpPut]
        [Route("Update Recipe")]
        //[Authorize(Roles = Role.Admin + "," + Role.User)]
        public async Task<IActionResult> Update(Recipe recipe)
        {
            if (recipe.Id == 0)
            {
                return NotFound("Id not found!");
            }

            await _recipeService.Update(recipe);

            return Ok(new { Result = "Success", Message = "Update successfully" });
        }

        [HttpDelete]
        [Route("Delete By {id}")]
        //[Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> RemoveById(int id)
        {
            var recipe = await _recipeService.GetById(id);
            if (recipe == null)
            {
                return NotFound("Id not found!");
            }

            await _recipeService.RemoveById(id);

            return Ok(new { Result = "Success", Message = "Delete successfully" });
        }

        [HttpGet]
        [Route("Search By Recipe")]
        public async Task<ActionResult<List<Recipe>>> GetRecipesByName(string name)
        {
            var recipes = _mapper.Map<List<Recipe>>(await _recipeService.GetRecipesByName(name));

            if (recipes == null)
            {
                return NotFound("None Recipe found");
            }

            return Ok(recipes);
        }

        [HttpGet]
        [Route("Search By Ingredient")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Recipe>>> SearchRecipeByIngredient(string name)
        {
            var recipes = _mapper.Map<List<Recipe>>(await _recipeService.SearchRecipeByIngredient(name));

            if (recipes == null)
            {
                return NotFound("None Recipe found");
            }

            return Ok(recipes);
        }

        [HttpGet]
        [Route("Search By Category")]
        //[Authorize(Roles = "User")]
        public async Task<ActionResult<List<Recipe>>> GetRecipeByCategory(string name)
        {
            var recipes = _mapper.Map<List<Recipe>>(await _recipeService.GetRecipeByCategory(name));

            if (recipes == null)
            {
                return NotFound("None Recipe found");
            }

            return Ok(recipes);
        }
    }
}
