namespace SchoolManagementAPI.ViewModels;

public class ResponseMessageVM
{
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
    public int UserId { get; set; }
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
