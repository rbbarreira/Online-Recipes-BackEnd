using Online_Recipes_Domain.Models;

namespace Online_Recipes_Service.Service_Interfaces
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> GetAll();

        Task<Ingredient> GetById(int id);

        Task<Ingredient> Add(Ingredient ingredient);

        Task<Ingredient> Update(Ingredient ingredient);

        Task<Ingredient> RemoveById(int id);

        Task<IEnumerable<Ingredient>> GetIngredientByName(string product);
    }
}
