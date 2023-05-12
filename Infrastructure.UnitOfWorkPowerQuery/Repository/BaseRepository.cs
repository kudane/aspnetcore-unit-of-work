using Infrastructure.Data;

namespace Infrastructure.UnitOfWorkPowerQuery.Repository
{
    public abstract class BaseRepository
    {
        protected SchoolContext context;

        public BaseRepository(SchoolContext context)
        {
            this.context = context;
        }
    }
}
