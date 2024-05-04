using Microsoft.EntityFrameworkCore;
using Online_Recipes_Data.Context;
using Online_Recipes_Domain.Models;
using Online_Recipes_Repository.Repo_Interfaces;

namespace Online_Recipes_Repository.Repo_Implementations
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<IEnumerable<Ingredient>> GetIngredientByName(string product)
        {
            return await _dbSet.Where(x => x.Product.ToLower().Contains(product.ToLower())).ToListAsync();
        }

        public async Task<List<Ingredient>> GetAll()
        {
            return await _dbSet.Include(a => a.Ingredient_Quantities).ToListAsync();
        }
    }
}
