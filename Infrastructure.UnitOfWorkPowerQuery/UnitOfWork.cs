using Infrastructure.Data;
using Infrastructure.Data.Seed;
using Infrastructure.UnitOfWorkPowerQuery.Interface;
using Infrastructure.UnitOfWorkPowerQuery.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorkPowerQuery
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext context;
        private IStudentRepository studentRepository;
        private ISummaryStudentReportRepository summaryStudentReportRepository;

        #region For Checking
        public void DatabaseEnsureCreated()
        {
            if (context != null)
            {
                context.Database.EnsureCreated();
            }
        }
        #endregion

        #region Seeding
        public void InitalSeedingIfNotExists()
        {
            if (context != null)
            {
                context.AddSeeding();
            }
        }
        #endregion

        #region Constructor
        public UnitOfWork()
        {
            context = new SchoolContext(new DbContextOptionsBuilder<SchoolContext>().Options);
        }

        public UnitOfWork(SchoolContext context)
        {
            this.context = context;
        }
        #endregion

        #region Unit of work
        public IStudentRepository StudentRepository
        {
            get
            {
                studentRepository ??= new StudentRepository(context);

                return studentRepository;
            }
        }

        public ISummaryStudentReportRepository SummaryStudentReportRepository
        {
            get
            {
                summaryStudentReportRepository ??= new SummaryStudentReportRepository(context);

                return summaryStudentReportRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        #endregion

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
