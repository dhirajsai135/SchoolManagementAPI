namespace SchoolManagementAPI.Abstractions;

public interface IEnrollmentService
{
    List<EnrollmentVM> GetEnrollmentAsync();
}
