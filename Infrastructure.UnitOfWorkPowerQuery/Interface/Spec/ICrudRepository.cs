using System.Linq.Expressions;

namespace Infrastructure.UnitOfWorkPowerQuery.Interface.Spec
{
    public interface ICrudRepository<TEntity>
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
