using PowerQuery = Infrastructure.UnitOfWorkPowerQuery;
using Crud = Infrastructure.UnitOfWorkCrud;

// CRUD Pattern
using (var unitOfWork = new Crud.UnitOfWork())
{
    unitOfWork.DatabaseEnsureCreated();

    unitOfWork.InitalSeedingIfNotExists();

    var students = unitOfWork.StudentRepository.List();

    var studentOrNull = unitOfWork.StudentRepository.Find(1);

    if (studentOrNull != null)
    {
        studentOrNull.FirstMidName = "last mid name";

        unitOfWork.StudentRepository.Update(studentOrNull);

        unitOfWork.Save();

        // other repository
        var enrollment = unitOfWork.EnrollmentRepository.Find(1);
    }
}

// Business Power Query Pattern
using (var unitOfWork = new PowerQuery.UnitOfWork())
{
    unitOfWork.DatabaseEnsureCreated();

    unitOfWork.InitalSeedingIfNotExists();

    // crud simple
    var students_Tracking = unitOfWork.StudentRepository.List();

    var student_Tracking = unitOfWork.StudentRepository.Find(1);

    if (student_Tracking != null)
    {
        student_Tracking.FirstMidName = "last mid name";

        unitOfWork.StudentRepository.Update(student_Tracking);

        unitOfWork.Save();
    }

    // Power Query
    var students_NoTracking = unitOfWork
        .StudentRepository
        .GetStudentBySearchData(1, "simple name", 1);

    var rawDataReport_NoTracking = unitOfWork
        .SummaryStudentReportRepository
        .GetSummaryAllStudent();

    Console.WriteLine("Show Report:.....");
    foreach (var item in rawDataReport_NoTracking)
    {
        Console.WriteLine(item.Fullname, item.EnrollmentsCount);
    }
}