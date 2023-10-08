
namespace SchoolManagementAPI.Models;

// A class to represent a student
public class Student
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public string? Phone { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }
    [ForeignKey("Class")]
    public int ClassId { get; set; }
    public virtual required Class Class { get; set; }
    public virtual ICollection<Enrollment>? Enrollments { get; set; }
}
