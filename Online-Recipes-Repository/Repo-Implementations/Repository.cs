using Microsoft.EntityFrameworkCore;
using Online_Recipes_Data.Context;
using Online_Recipes_Domain.Models;
using Online_Recipes_Repository.Repo_Interfaces;
using System.Linq.Expressions;

namespace Online_Recipes_Repository.Repo_Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationContext _applicationContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _dbSet = applicationContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll()
        {

            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);

            _dbSet.Entry(entity).State = EntityState.Modified;

            await SaveChanges();

            return entity;
        }

        public async Task<TEntity> RemoveById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChanges();
            }

            return null;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
