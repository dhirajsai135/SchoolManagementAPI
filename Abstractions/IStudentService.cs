namespace SchoolManagementAPI.Abstractions;

public interface IStudentService
{
    Task<List<Student>> GetAllAsync();
}
