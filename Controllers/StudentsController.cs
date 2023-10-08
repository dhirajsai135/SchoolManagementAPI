using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;

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
    public async Task<ActionResult> GetAllAsync()
    {
        try
        {
            return Ok(await _studentService.GetAllAsync());
        }
        catch (Exception)
        {
            throw;
        }
    }
    [Route("GetById")]
    [HttpGet]
    public async Task<ActionResult> GetAsync(int id)
    {
        try
        {
            return Ok(await _studentService.GetAsync(id));
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult> SaveAsync([FromBody]Student student)
    {
        try
        {
            return Ok(await _studentService.SaveAsync(student));
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Student>> DeleteStudent(int id)
    {
        try
        {
            return Ok(await _studentService.DeleteAsync(id));
        }
        catch (Exception)
        {
            throw;
        }
    }
}
