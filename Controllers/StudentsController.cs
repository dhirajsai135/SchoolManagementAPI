namespace SchoolManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly StudentContext _studentContext;
    public StudentsController(StudentContext studentContext)
    {
        _studentContext = studentContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAllAsync()
    {
        if (_studentContext == null)
        {
            return NotFound();
        }
        return await (_studentContext.Students.ToListAsync());
    }
}
