namespace SchoolManagementAPI.Abstractions;

public interface IClassService
{
    Task<List<ClassVM>> GetAllAsync();
    Task<bool> SaveAsync(Class classVM);
    Task<ClassVM> GetAsync(int classId);
    Task<bool> DeleteAsync(int classId);
}
