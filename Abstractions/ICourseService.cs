namespace SchoolManagementAPI.Abstractions;

public interface ICourseService
{
    Task<List<CourseVM>> GetAllAsync();
    Task<bool> SaveAsync(Course enrollment);
    Task<CourseVM> GetAsync(int enrollmentId);
    Task<bool> DeleteAsync(int enrollmentId);
}
