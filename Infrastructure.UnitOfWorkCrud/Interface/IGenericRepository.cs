using System.Linq.Expressions;

namespace Infrastructure.UnitOfWorkCrud.Interface
{
    public interface IGenericRepository<TEntity>
    {
        // CRUD
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        // Query
        TEntity Find(int key);
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter = null);
    }
}
