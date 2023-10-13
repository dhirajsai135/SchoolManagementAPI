namespace SchoolManagementAPI.Service;

public class ClassService : IClassService
{
    private readonly StudentContext _studentContext;
    private readonly IMapper _mapper;
    public ClassService(StudentContext studentContext, IMapper mapper)
    {
        _studentContext = studentContext;
        _mapper = mapper;
    }
    public async Task<List<ClassVM>> GetAllAsync()
    {
        if (_studentContext == null)
        {
            return new List<ClassVM>();
        }
        var response = await _studentContext.Classes.ToListAsync();
        return _mapper.Map<List<ClassVM>>(response);
    }

    public async Task<ClassVM> GetAsync(int classId)
    {
        ClassVM classVM = new();
        if (_studentContext == null)
        {
            return classVM;
        }
        var response = await _studentContext.Classes.FindAsync(classId);
        if (response == null)
        {
            return classVM;
        }
        var result = _mapper.Map<ClassVM>(response);
        return result;
    }

    public async Task<bool> SaveAsync(Class classVM)
    {
        if (classVM == null) { return false; }
        await _studentContext.Classes.AddAsync(classVM);
        await _studentContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int classId)
    {
        var classVM = await _studentContext.Classes.FindAsync(classId);
        if (_studentContext == null)
        {
            return false;
        }
        if (classVM == null)
        {
            return false;
        }
        _studentContext.Classes.Remove(classVM);
        await _studentContext.SaveChangesAsync();
        return true;
    }
}
