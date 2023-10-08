namespace SchoolManagementAPI.Models;

public class Course
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [Range(1, 5)]
    public int Credits { get; set; }

    public virtual ICollection<Enrollment>? Enrollments { get; set; }
}
