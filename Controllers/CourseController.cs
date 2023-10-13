// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService enrollmentService)
    {
        _courseService = enrollmentService;
    }
    [HttpGet("GetAll")]
    public async Task<ActionResult> GetAllAsync()
    {
        try
        {
            return Ok(await _courseService.GetAllAsync());
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        try
        {
            return Ok(await _courseService.GetAsync(id));
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPost]
    public async Task<ActionResult> SaveAsync([FromBody] Course course)
    {
        try
        {
            return Ok(await _courseService.SaveAsync(course));
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            return Ok(await _courseService.DeleteAsync(id));
        }
        catch (Exception)
        {
            throw;
        }
    }
}
