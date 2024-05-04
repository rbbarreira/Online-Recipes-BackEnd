using Online_Recipes_Domain.Models;
using Online_Recipes_Repository.Repo_Interfaces;
using Online_Recipes_Service.Service_Interfaces;

namespace Online_Recipes_Service.Service_Implementations
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<List<Ingredient>> GetAll()
        {
            return await _ingredientRepository.GetAll();
        }

        public async Task<Ingredient> GetById(int id)
        {
            return await _ingredientRepository.GetById(id);
        }

        public async Task<Ingredient> Add(Ingredient ingredient)
        {
            return await _ingredientRepository.Add(ingredient);
        }

        public async Task<Ingredient> Update(Ingredient ingredient)
        {
            return await _ingredientRepository.Update(ingredient);
        }

        public async Task<Ingredient> RemoveById(int id)
        {
            var ingredient = await _ingredientRepository.GetById(id);

            if (ingredient != null)
            {
                return await _ingredientRepository.RemoveById(id);
            }

            return null;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientByName(string product)
        {
            return await _ingredientRepository.GetIngredientByName(product);
        }
    }
}
