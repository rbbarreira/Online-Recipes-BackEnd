using Online_Recipes_Domain.Models;

namespace Online_Recipes_Repository.Repo_Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //Procura a Categoria pelo nome
        Task<IEnumerable<Category>> GetCategoryByName(string name);
    }
}
