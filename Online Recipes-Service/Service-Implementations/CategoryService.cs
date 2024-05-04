using Online_Recipes_Domain.Models;
using Online_Recipes_Repository.Repo_Interfaces;
using Online_Recipes_Service.Service_Interfaces;

namespace Online_Recipes_Service.Service_Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Category> Add(Category category)
        {
            return await _categoryRepository.Add(category);
        }

        public async Task<Category> Update(Category category)
        {
            return await _categoryRepository.Update(category);
        }

        public async Task<Category> RemoveById(int id)
        {
            var category = await _categoryRepository.GetById(id);

            if (category != null)
            {
                return await _categoryRepository.RemoveById(id);
            }

            return null;
        }

        public async Task<IEnumerable<Category>> GetCategoryByName(string name)
        {
            return await _categoryRepository.GetCategoryByName(name);
        }
    }
}
