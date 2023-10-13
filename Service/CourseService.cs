namespace SchoolManagementAPI.Service;

public class CourseService : ICourseService
{
    private readonly StudentContext _studentContext;
    private readonly IMapper _mapper;
    public CourseService(StudentContext studentContext, IMapper mapper)
    {
        _studentContext = studentContext;
        _mapper = mapper;
    }
    public async Task<List<CourseVM>> GetAllAsync()
    {
        if (_studentContext == null)
        {
            return new List<CourseVM>();
        }
        var response = await _studentContext.Courses.ToListAsync();
        return _mapper.Map<List<CourseVM>>(response);
    }

    public async Task<CourseVM> GetAsync(int enrollmentId)
    {
        CourseVM course = new();
        if (_studentContext == null)
        {
            return course;
        }
        var response = await _studentContext.Courses.FindAsync(enrollmentId);
        if (response == null)
        {
            return course;
        }
        var result = _mapper.Map<CourseVM>(response);
        return result;
    }

    public async Task<bool> SaveAsync(Course course)
    {
        if (course == null) { return false; }
        await _studentContext.Courses.AddAsync(course);
        await _studentContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int enrollmentId)
    {
        var course = await _studentContext.Courses.FindAsync(enrollmentId);
        if (_studentContext == null)
        {
            return false;
        }
        if (course == null)
        {
            return false;
        }
        _studentContext.Courses.Remove(course);
        await _studentContext.SaveChangesAsync();
        return true;
    }
}
