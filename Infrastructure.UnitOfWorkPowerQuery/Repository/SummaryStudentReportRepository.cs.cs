using Infrastructure.Data;
using Infrastructure.UnitOfWorkPowerQuery.Dto;
using Infrastructure.UnitOfWorkPowerQuery.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorkPowerQuery.Repository
{
    public class SummaryStudentReportRepository : BaseRepository, ISummaryStudentReportRepository
    {
        public SummaryStudentReportRepository(SchoolContext context) : base(context)
        {
        }

        public IEnumerable<SummaryStudentReportDto> GetSummaryAllStudent()
        {
            return context.Students
                .AsNoTracking()
                .Select(a => new SummaryStudentReportDto()
                {
                    StudentID = a.StudentID,
                    Fullname = $"{a.FirstMidName} {a.LastName}",
                    EnrollmentsCount = a.Enrollments.Count(),
                })
                .ToList();
        }
    }
}
