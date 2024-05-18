using Online_Recipes_Domain.Models;
using Online_Recipes_Repository.Repo_Interfaces;
using Online_Recipes_Service.Service_Interfaces;

namespace Online_Recipes_Service.Service_Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RecipeService(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, ICategoryRepository categoryRepository)
        {
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Recipe>> GetAll()
        {
            return await _recipeRepository.GetAll();
        }

        public async Task<Recipe> GetById(int id)
        {
            return await _recipeRepository.GetById(id);
        }

        public async Task<Recipe> Add(Recipe recipe)
        {
            // Não repetir ingredientes
            var fixed_ingredients = new List<Ingredient>();

            foreach (var ingredient in recipe.Ingredients)
            {
                var existing = (await _ingredientRepository.GetIngredientByName(ingredient.Product)).FirstOrDefault();
                if (existing != null)
                {
                    fixed_ingredients.Add(existing);
                }
                else fixed_ingredients.Add(ingredient);
            }
            recipe.Ingredients = fixed_ingredients;

            //Não repetir categorias
            var fixed_categories = new List<Category>();

            foreach (var category in recipe.Categories)
            {
                var existing = (await _categoryRepository.GetCategoryByName(category.Name)).FirstOrDefault();
                if (existing != null)
                {
                    fixed_categories.Add(existing);
                }
                else fixed_categories.Add(category);
            }
            recipe.Categories = fixed_categories;            
            

            return await _recipeRepository.Add(recipe);
        }

        public async Task<Recipe> Update(Recipe recipe)
        {
            //Não repetir ingredientes
            var fixed_ingredients = new List<Ingredient>();

            foreach (var ingredient in recipe.Ingredients)
            {
                var existing = (await _ingredientRepository.GetIngredientByName(ingredient.Product)).FirstOrDefault();
                if (existing != null)
                {
                    //fixed_ingredients.Add(existing);
                }
                else fixed_ingredients.Add(ingredient);
            }
            recipe.Ingredients = fixed_ingredients;

            //Não repetir categorias
            var fixed_categories = new List<Category>();

            foreach (var category in recipe.Categories)
            {
                var existing = (await _categoryRepository.GetCategoryByName(category.Name)).FirstOrDefault();
                if (existing != null)
                {
                    //fixed_categories.Add(existing);
                }
                else fixed_categories.Add(category);
            }
            recipe.Categories = fixed_categories;        

            await _recipeRepository.Update(recipe);

            return(recipe);
        }

        public async Task<Recipe> RemoveById(int id)
        {
            return await _recipeRepository.RemoveById(id);
        }

        public async Task<bool> Delete(Recipe recipe)
        {
            await _recipeRepository.Delete(recipe);

            return true;
        }

        public async Task<IEnumerable<Recipe>> GetRecipesByName(string name)
        {
            return await _recipeRepository.GetRecipesByName(name);
        }

        public async Task<IEnumerable<Recipe>> SearchRecipeByIngredient(string name)
        {
            return await _recipeRepository.SearchRecipeByIngredient(name);
        }

        public async Task<IEnumerable<Recipe>> GetRecipeByCategory(string name)
        {
            return await _recipeRepository.GetRecipeByCategory(name);
        }
    }
}
