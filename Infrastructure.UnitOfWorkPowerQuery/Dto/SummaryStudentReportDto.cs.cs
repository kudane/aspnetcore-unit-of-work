using Infrastructure.Data;

namespace Infrastructure.UnitOfWorkPowerQuery.Dto
{
    public class SummaryStudentReportDto
    {
        public int StudentID { get; set; }
        public string Fullname { get; set; } = null!;
        public int EnrollmentsCount { get; set; }
    }
}
