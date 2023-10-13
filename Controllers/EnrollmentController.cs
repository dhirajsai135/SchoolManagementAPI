namespace SchoolManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentController : ControllerBase
{
	private readonly IEnrollmentService _enrollmentService;
    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }
    [HttpGet("GetAll")]
    public async Task<ActionResult> GetAllAsync()
    {
        try
        {
            return Ok(await _enrollmentService.GetAllAsync());
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
            return Ok(await _enrollmentService.GetAsync(id));
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult> SaveAsync([FromBody] Enrollment enrollment)
    {
        try
        {
            return Ok(await _enrollmentService.SaveAsync(enrollment));
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
            return Ok(await _enrollmentService.DeleteAsync(id));
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpGet("GetEnrollmentBasedOnStudents")]
    public ActionResult GetEnrollmentBasedOnStudentsAsync()
    {
		try
		{
			var response = _enrollmentService.GetEnrollmentBasedOnStudentsAsync();
			return Ok(response);
		}
		catch (Exception)
		{
			throw;
		}
    }
}
