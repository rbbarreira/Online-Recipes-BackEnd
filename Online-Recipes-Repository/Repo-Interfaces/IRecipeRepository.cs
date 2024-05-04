using Online_Recipes_Domain.Models;

namespace Online_Recipes_Repository.Repo_Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        //Procuar uma Receita pelo Nome
        Task<IEnumerable<Recipe>> GetRecipesByName(string name);

        //Procuar uma Receita pelo Ingredient
        Task<IEnumerable<Recipe>> SearchRecipeByIngredient(string name);

        //Procuar uma Receita pela Categoria
        Task<IEnumerable<Recipe>> GetRecipeByCategory(string name);
    }
}
