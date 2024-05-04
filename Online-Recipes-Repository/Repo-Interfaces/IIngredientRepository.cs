using Online_Recipes_Domain.Models;

namespace Online_Recipes_Repository.Repo_Interfaces
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        //Procura um Ingrediente pelo Produto(nome)
        Task<IEnumerable<Ingredient>> GetIngredientByName(string product);
    }
}
