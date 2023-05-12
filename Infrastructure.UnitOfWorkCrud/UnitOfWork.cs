using Infrastructure.Data;
using Infrastructure.Data.Seed;
using Infrastructure.UnitOfWorkCrud.Interface;
using Infrastructure.UnitOfWorkCrud.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorkCrud
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext context;
        private IGenericRepository<Student> studentRepository;
        private IGenericRepository<Enrollment> enrollmentRepository;

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
        public IGenericRepository<Student> StudentRepository
        {
            get
            {
                studentRepository ??= new GenericRepository<Student>(context);

                return studentRepository;
            }
        }

        public IGenericRepository<Enrollment> EnrollmentRepository
        {
            get
            {
                enrollmentRepository ??= new GenericRepository<Enrollment>(context);

                return enrollmentRepository;
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
