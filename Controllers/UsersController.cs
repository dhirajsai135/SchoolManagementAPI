namespace SchoolManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [Route("Login")]
    [HttpPost]
    public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        try
        {
            return Ok(await _userService.Login(loginRequest.Email, loginRequest.Password));
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpGet]
    public async Task<ActionResult> GetUsers()
    {
        try
        {
            return Ok(await _userService.GetUsers());
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        try
        {
            return Ok(await _userService.GetUser(id));
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(UserVM user)
    {
        try
        {
            return Ok(await _userService.SaveUser(user));
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            return Ok(await _userService.DeleteUser(id));
        }
        catch (Exception)
        {

            throw;
        }
    }


}
