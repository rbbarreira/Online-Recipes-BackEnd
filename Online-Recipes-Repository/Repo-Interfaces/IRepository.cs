using Online_Recipes_Domain.Models;
using System.Linq.Expressions;

namespace Online_Recipes_Repository.Repo_Interfaces
{
    //Esta Class vai implementar o Interface em todas as Class com o TEntity
    public interface IRepository<TEntity> where TEntity : Entity
    {
        //Lista todos os valores de uma Entidade (Class)
        Task<List<TEntity>> GetAll();

        //Devolve uma Entity pelo ID
        Task<TEntity> GetById(int id);

        //Adiciona uma Entidade (Class)
        Task<TEntity> Add(TEntity entity);

        //Atualiza uma Entidade (Class)
        Task<TEntity> Update(TEntity entity);

        //Elimina uma Entidade (Class) pelo ID
        Task<TEntity> RemoveById(int id);

        //Elimina uma Entidade (Class)
        Task<TEntity> Delete(TEntity entity);

        //Procura valores passando uma Lambda Expression para procurar em uma Entidade (Class)
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

        //Grava as alterações a uma Entidade (Class)
        Task SaveChanges();
    }
}
