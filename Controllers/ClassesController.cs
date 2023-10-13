namespace SchoolManagementAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ClassesController : ControllerBase
{
    private readonly IClassService _classService;
    public ClassesController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllAsync()
    {
        try
        {
            return Ok(await _classService.GetAllAsync());
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
            return Ok(await _classService.GetAsync(id));
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult> SaveAsync([FromBody] Class classVM)
    {
        try
        {
            return Ok(await _classService.SaveAsync(classVM));
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
            return Ok(await _classService.DeleteAsync(id));
        }
        catch (Exception)
        {
            throw;
        }
    }
}
