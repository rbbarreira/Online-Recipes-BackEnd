using Online_Recipes_Domain.Models;

namespace Online_Recipes_Service.Service_Interfaces
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetAll();

        Task<Recipe> GetById(int id);

        Task<Recipe> Add(Recipe recipe);

        Task<Recipe> Update(Recipe recipe);

        Task<Recipe> RemoveById(int id);

        Task<bool> Delete(Recipe recipe);

        Task<IEnumerable<Recipe>> GetRecipesByName(string name);

        Task<IEnumerable<Recipe>> SearchRecipeByIngredient(string name);

        Task<IEnumerable<Recipe>> GetRecipeByCategory(string name);
    }
}
