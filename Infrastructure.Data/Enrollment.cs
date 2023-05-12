namespace Infrastructure.Data
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public string CourseName { get; set; }
        public int StudentID { get; set; }

        public virtual Student Student { get; set; }
    }
}
