using System.Linq.Expressions;

namespace Infrastructure.UnitOfWorkPowerQuery.Interface.Spec
{
    public interface IBasicQueryRepository<TEntity>
    {
        TEntity Find(int key);
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter = null);
    }
}
