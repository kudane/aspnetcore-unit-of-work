using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public partial class SchoolContext : DbContext
    {
        public string DbPath { get; }

        public SchoolContext() { }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<CheckingSeed> CheckingSeeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=app_db.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasKey(e => e.StudentID);

                entity.HasIndex(e => e.StudentID, "IX_Student_StudentID").IsUnique();

                entity.HasMany(e => e.Enrollments)
                    .WithOne(e => e.Student)
                    .HasForeignKey(e => e.StudentID);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.EnrollmentID);

                entity.ToTable("Enrollment");

                entity.HasIndex(e => e.EnrollmentID, "IX_Enrollment_EnrollmentID").IsUnique();
            });

            modelBuilder.Entity<CheckingSeed>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Id, "IX_Checking_Id").IsUnique();

                entity.ToTable("CheckingSeed");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
