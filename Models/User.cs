namespace SchoolManagementAPI.Models;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter FirstName")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter LastName")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Gender")]
    public string Gender { get; set; }

    [Required]
    public string Email { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    public Role UserRole { get; set; }
}