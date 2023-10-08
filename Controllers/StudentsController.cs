namespace SchoolManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAllAsync()
    {
        try
        {
            return await _studentService.GetAllAsync();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
