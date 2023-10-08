namespace SchoolManagementAPI.Abstractions;

public interface IStudentService
{
    Task<List<Student>> GetAllAsync();
    Task<bool> SaveAsync(Student student);
    Task<StudentVM> GetAsync(int studentId);
    Task<bool> DeleteAsync(int studentId);
}
