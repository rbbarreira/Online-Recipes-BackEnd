using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Recipes_Domain.Account;
using Online_Recipes_Domain.Models;
using Online_Recipes_Service.Service_Interfaces;

namespace Online_Recipes_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryServices)
        {
            _categoryService = categoryServices;
        }

        [HttpGet]
        [Route("List Category")]
        public async Task<ActionResult<List<Category>>> GetCategorys()
        {
            var category = await _categoryService.GetAll();

            return Ok(category);
        }

        [HttpGet]
        [Route("Search By {id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound("Id not found!");
            }

            return Ok(category);
        }

        [HttpPost]
        [Route("Create Category")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Add(Category category)
        {
            var exist = await _categoryService.Add(category);

            if (exist == null)
            {
                return BadRequest("Error occour while creating!");
            }

            return Ok(new { Result = "Success", Message = "Create successfully" });
        }

        [HttpPut]
        [Route("Update Category")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Update(Category category)
        {
            var exist = await _categoryService.Update(category);

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
            var exist = await _categoryService.GetById(id);

            if (exist == null)
            {
                return NotFound("Id not found!");
            }

            await _categoryService.RemoveById(id);

            return Ok(new { Result = "Success", Message = "Delete successfully" });
        }
    }
}
