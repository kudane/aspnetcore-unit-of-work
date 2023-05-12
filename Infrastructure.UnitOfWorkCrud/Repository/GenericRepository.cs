using Infrastructure.Data;
using Infrastructure.UnitOfWorkCrud.Interface;
using System.Linq.Expressions;

namespace Infrastructure.UnitOfWorkCrud.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected SchoolContext context;

        public GenericRepository(SchoolContext context)
        {
            this.context = context;
        }

        #region CRUD
        public void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            context.Set<TEntity>().Update(entityToUpdate);
        }

        public void Delete(TEntity entityToDelete)
        {
            context.Set<TEntity>().Remove(entityToDelete);
        }
        #endregion

        #region Query
        public TEntity Find(int key)
        {
            return context.Set<TEntity>().Find(key);
        }

        public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }
        #endregion
    }
}
