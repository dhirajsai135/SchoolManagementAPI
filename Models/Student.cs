namespace SchoolManagementAPI.Models;

public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public required string Class { get; set; }
    public required string Address { get; set; }
}
