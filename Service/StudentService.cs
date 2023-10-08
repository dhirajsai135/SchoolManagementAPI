namespace SchoolManagementAPI.Service;

public class StudentService : IStudentService
{
    private readonly StudentContext _studentContext;
    public StudentService(StudentContext studentContext)
    {
        _studentContext = studentContext;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        if (_studentContext == null)
        {
            return new List<Student>();
        }
        return (await _studentContext.Students.ToListAsync());
    }
}
