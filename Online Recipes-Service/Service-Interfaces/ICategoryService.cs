using Online_Recipes_Domain.Models;

namespace Online_Recipes_Service.Service_Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();

        Task<Category> GetById(int id);

        Task<Category> Add(Category category);

        Task<Category> Update(Category category);

        Task<Category> RemoveById(int id);

        Task<IEnumerable<Category>> GetCategoryByName(string name);
    }
}
