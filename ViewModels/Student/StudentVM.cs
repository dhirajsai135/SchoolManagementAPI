namespace SchoolManagementAPI.ViewModels;

public class StudentVM
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Class { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
