using Microsoft.EntityFrameworkCore;
using Online_Recipes_Data.Context;
using Online_Recipes_Domain.Models;
using Online_Recipes_Repository.Repo_Interfaces;

namespace Online_Recipes_Repository.Repo_Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<IEnumerable<Category>> GetCategoryByName(string name)
        {
            return await _dbSet.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }
    }
}
