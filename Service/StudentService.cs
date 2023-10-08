namespace SchoolManagementAPI.Service;

public class StudentService : IStudentService
{
    private readonly StudentContext _studentContext;
    private readonly IMapper _mapper;
    public StudentService(StudentContext studentContext, IMapper mapper)
    {
        _studentContext = studentContext;
        _mapper = mapper;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        if (_studentContext == null)
        {
            return new List<Student>();
        }
        return (await _studentContext.Students.ToListAsync());
    }

    public async Task<StudentVM> GetAsync(int studentId)
    {
        StudentVM student = new();
        if (_studentContext == null)
        {
            return student;
        }
        var response = await _studentContext.Students.FindAsync(studentId);
        if (response == null)
        {
            return student;
        }
        var result = _mapper.Map<StudentVM>(response);
        return result;
    }

    public async Task<bool> SaveAsync(Student student)
    {
        if (student == null) { return false; }
        await _studentContext.Students.AddAsync(student);
        await _studentContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int studentId)
    {
        var student = await _studentContext.Students.FindAsync(studentId);
        if (_studentContext == null)
        {
            return false;
        }
        if (student == null)
        {
            return false;
        }
        _studentContext.Students.Remove(student);
        await _studentContext.SaveChangesAsync();
        return true;
    }
}
