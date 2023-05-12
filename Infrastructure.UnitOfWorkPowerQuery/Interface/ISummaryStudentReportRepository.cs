using Infrastructure.UnitOfWorkPowerQuery.Dto;

namespace Infrastructure.UnitOfWorkPowerQuery.Interface
{
    public interface ISummaryStudentReportRepository
    {
        IEnumerable<SummaryStudentReportDto> GetSummaryAllStudent();
    }
}
