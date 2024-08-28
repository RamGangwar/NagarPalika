using System.Linq.Expressions;

namespace NagarPalika.Application.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<int> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetALL();
        Task<IEnumerable<TEntity>> Get(object conditions);
        Task<TEntity> GetByClause(object conditions);
        Task<IEnumerable<TEntity>> GetByClauseList(object conditions);
        Task<TEntity> GetById(Object id);
    }
}
