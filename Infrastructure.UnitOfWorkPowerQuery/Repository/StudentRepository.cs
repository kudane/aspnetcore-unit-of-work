using Infrastructure.Data;
using Infrastructure.UnitOfWorkPowerQuery.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.UnitOfWorkPowerQuery.Repository
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context)
        {
        }

        #region CRUD Method
        public void Insert(Student entity)
        {
            context.Students.Add(entity);
        }

        public void Update(Student entity)
        {
            context.Students.Update(entity);
        }

        public void Delete(Student entity)
        {
            context.Students.Remove(entity);
        }
        #endregion

        #region Basic Query
        public Student Find(int key)
        {
            return context.Students.Where(a => a.StudentID == key).FirstOrDefault();
        }

        public IEnumerable<Student> List(Expression<Func<Student, bool>> filter = null)
        {
            var query = context.Students.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }
        #endregion

        #region Bussiness Power Query
        public IEnumerable<Student> GetStudentBySearchData(int id, string name, int someEnrollemntId)
        {
            var query = context.Students.AsNoTracking();

            if (id != 0)
            {
                query = query.Where(a => a.StudentID == id);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.FirstMidName.ToLower().Contains(name.ToLower()));
            }

            if (someEnrollemntId != 0)
            {
                query = query.Where(a => a.Enrollments.Any(b => b.EnrollmentID == someEnrollemntId));
            }

            return query.ToList();
        }
        #endregion
    }
}
