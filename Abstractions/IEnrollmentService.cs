namespace SchoolManagementAPI.Abstractions;

public interface IEnrollmentService
{
    Task<List<EnrollmentVM>> GetAllAsync();
    Task<bool> SaveAsync(Enrollment enrollment);
    Task<EnrollmentVM> GetAsync(int enrollmentId);
    Task<bool> DeleteAsync(int enrollmentId);
    List<StudentEnrollmentsVM> GetEnrollmentBasedOnStudentsAsync();
}
