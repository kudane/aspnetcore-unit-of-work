namespace Infrastructure.Data.Seed
{
    public static class InitalSeeding
    {
        public static void AddSeeding(this SchoolContext context)
        {
            if (context.CheckingSeeds.Any(a => a.HasSeeding == true))
            {
                return;
            }

            context.Students.Add(new Student
            {
                StudentID = 1,
                FirstMidName = " Mike",
                LastName = "Shinota",
                EnrollmentDate = DateTime.Now,
            });

            context.Students.Add(new Student
            {
                StudentID = 2,
                FirstMidName = " Sara",
                LastName = "Shoe",
                EnrollmentDate = DateTime.Now,
            });

            context.Students.Add(new Student
            {
                StudentID = 3,
                FirstMidName = " Niki",
                LastName = "Light",
                EnrollmentDate = DateTime.Now,
            });

            context.Enrollments.Add(new Enrollment
            {
                EnrollmentID = 1,
                StudentID = 1,
                CourseName = "Linear 1"
            });

            context.Enrollments.Add(new Enrollment
            {
                EnrollmentID = 2,
                StudentID = 1,
                CourseName = "Chemical 1"
            });

            context.Enrollments.Add(new Enrollment
            {
                EnrollmentID = 3,
                StudentID = 1,
                CourseName = "Music 1"
            });

            context.Enrollments.Add(new Enrollment
            {
                EnrollmentID = 4,
                StudentID = 2,
                CourseName = "Chemical 1"
            });

            context.Enrollments.Add(new Enrollment
            {
                EnrollmentID = 5,
                StudentID = 2,
                CourseName = "Music 1"
            });

            context.Enrollments.Add(new Enrollment
            {
                EnrollmentID = 6,
                StudentID = 3,
                CourseName = "Chemical 1"
            });

            context.Enrollments.Add(new Enrollment
            {
                EnrollmentID = 7,
                StudentID = 3,
                CourseName = "Music 1"
            });

            context.CheckingSeeds.Add(new CheckingSeed
            {
                Id = 1,
                HasSeeding = true,
            });

            context.SaveChanges();
        }
    }
}
