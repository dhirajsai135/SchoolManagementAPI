namespace SchoolManagementAPI.Abstractions;

public interface IUserService
{
    Task<List<UserVM>> GetUsers();
    Task<User> GetUser(int id);
    Task<User> SaveUser(UserVM user);
    Task<ResponseMessageVM> DeleteUser(int id);

    Task<ResponseMessageVM> Login(string email, string password);
}
