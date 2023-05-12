using Infrastructure.Data;
using Infrastructure.UnitOfWorkPowerQuery.Interface.Spec;

namespace Infrastructure.UnitOfWorkPowerQuery.Interface
{
    public interface IStudentRepository: ICrudRepository<Student>, IBasicQueryRepository<Student>
    {
        IEnumerable<Student> GetStudentBySearchData(int id, string name, int someEnrollemntId);
    }
}
