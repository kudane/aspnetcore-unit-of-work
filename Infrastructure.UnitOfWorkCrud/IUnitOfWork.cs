namespace Infrastructure.UnitOfWorkCrud
{
    public interface IUnitOfWork : IDisposable
    {
        void DatabaseEnsureCreated();
        void InitalSeedingIfNotExists();
        void Save();
    }
}
