namespace SchoolManagementAPI.Models;

public class Enrollment
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public virtual required Student Student { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public virtual required Course Course { get; set; }

    [Range(0, 100)]
    public int Grade { get; set; }
}
