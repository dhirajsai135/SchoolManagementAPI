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
    [HttpGet]
    public async Task<ActionResult> GetEnrollments()
    {
		try
		{
			var response = await _enrollmentService.GetEnrollmentAsync();
			return Ok(response);
		}
		catch (Exception)
		{
			throw;
		}
    }
}
