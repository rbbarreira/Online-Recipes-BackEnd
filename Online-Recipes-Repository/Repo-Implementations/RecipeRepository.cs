using Microsoft.EntityFrameworkCore;
using Online_Recipes_Data.Context;
using Online_Recipes_Domain.Models;
using Online_Recipes_Repository.Repo_Interfaces;

namespace Online_Recipes_Repository.Repo_Implementations
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<IEnumerable<Recipe>> GetRecipesByName(string name)
        {
            return await _dbSet.Include(a => a.Ingredients)
                               .ThenInclude(b => b.Ingredient_Quantities)
                               .Include(c => c.Preparations)
                               .Include(b => b.Categories)
                               .Where(e => e.Name.ToLower().Contains(name.ToLower()))
                               .ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> SearchRecipeByIngredient(string name)
        {
            return await _dbSet.Include(a => a.Ingredients)
                               .ThenInclude(b => b.Ingredient_Quantities)
                               .Include(c => c.Preparations)
                               .Include(b => b.Categories)
                               .Where(e => e.Ingredients.Any(f => f.Product == name.ToLower()))
                               .ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipeByCategory(string name)
        {
            return await _dbSet.Include(a => a.Ingredients)
                               .ThenInclude(b => b.Ingredient_Quantities)
                               .Include(c => c.Preparations)
                               .Include(b => b.Categories)
                               .Where(e => e.Categories.Any(f => f.Name == name.ToLower()))
                               .ToListAsync();
        }

        public async Task<List<Recipe>> GetAll()
        {
            return await _dbSet.Include(a => a.Ingredients)
                               .ThenInclude(b => b.Ingredient_Quantities)
                               .Include(c => c.Preparations)
                               .Include(b => b.Categories)
                               .ToListAsync();
        }

        public async Task<Recipe> GetById(int id)
        {
            var recipe = await _dbSet.Include(a => a.Ingredients)
                                     .ThenInclude(b => b.Ingredient_Quantities)
                                     .Include(c => c.Preparations)
                                     .Include(d => d.Categories)
                                     .FirstOrDefaultAsync(x => x.Id == id);

            return recipe;
        }

        //Atualiza a Receita bem com Ingrediente e Categoria quando inserido na receita
        public async Task Update(Recipe recipe)
        {
            Recipe exist = _applicationContext.Recipes
                .Include(a => a.Categories)
                .Include(b => b.Ingredients)
                .Single(c => c.Id == recipe.Id);

            _applicationContext.Entry(exist).CurrentValues.SetValues(recipe);

            exist.Ingredients.Clear();
            foreach (var i in recipe.Ingredients) exist.Ingredients.Add(i);

            exist.Categories.Clear();
            foreach (var c in recipe.Categories) exist.Categories.Add(c);

            _applicationContext.Recipes.Update(exist);
            await SaveChanges();
        }
    }
}
