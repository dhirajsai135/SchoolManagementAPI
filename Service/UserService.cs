namespace SchoolManagementAPI.Service;

public class UserService : IUserService
{
    private readonly StudentContext _context;
    private readonly IMapper _mapper;
    public UserService(StudentContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserVM>> GetUsers()
    {
        if (_context.Users == null)
        {
            return new List<UserVM>();
        }
        return _mapper.Map<List<UserVM>>(await _context.Users.ToListAsync());
    }

    public async Task<User> GetUser(int id)
    {
        if (_context.Users == null)
        {
            return new User();
        }
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return new User();
        }

        return user;
    }

    public async Task<User> SaveUser(UserVM user)
    {
        var newUser = _mapper.Map<User>(user);
        if (_context.Users == null)
        {
            return newUser;
        }
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return await GetUser(newUser.Id);
    }

    public async Task<ResponseMessageVM> DeleteUser(int id)
    {
        if (_context.Users == null)
        {
            return new ResponseMessageVM { IsSuccessful = false, Message = "User Deletion Failed" };
        }
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return new ResponseMessageVM { IsSuccessful = false, Message = "User Not found" };
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return new ResponseMessageVM { IsSuccessful = true, Message = "User Deleted Successfully" };
    }

    private bool UserExists(int id)
    {
        return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    public async Task<ResponseMessageVM> Login(string email, string password)
    {
        if (_context.Users == null)
        {
            return new ResponseMessageVM { IsSuccessful = false, Message = "No User Exist" };
        }

        var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == email);

        if (user == null)
        {
            return new ResponseMessageVM { IsSuccessful = false, Message = "User Does not Exist" };
        }

        if (user.Password != password)
        {
            return new ResponseMessageVM { IsSuccessful = false, Message = "Password Which you have entered is incorrect" };
        }

        return new ResponseMessageVM { IsSuccessful = true, UserId = user.Id };
    }
}
