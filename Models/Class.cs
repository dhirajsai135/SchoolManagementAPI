namespace SchoolManagementAPI.Models
{
    public class Class
    {
        // A property to store the class id
        [Key]
        public int Id { get; set; }

        // A property to store the class name
        [Required]
        public string? Name { get; set; }

        // A property to store the class section
        [Required]
        public string? Section { get; set; }

        // A navigation property to link the class with the students
        public virtual ICollection<Student> Students { get; set; }

        // A navigation property to link the class with the courses
        public virtual ICollection<Course> Courses { get; set; }
    }
}
