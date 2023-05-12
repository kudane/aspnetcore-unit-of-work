namespace Infrastructure.UnitOfWorkPowerQuery
{
    public interface IUnitOfWork : IDisposable
    {
        void DatabaseEnsureCreated();
        void InitalSeedingIfNotExists();
        void Save();
    }
}
