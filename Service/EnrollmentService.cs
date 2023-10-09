using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace SchoolManagementAPI.Service;

public class EnrollmentService : IEnrollmentService
{
    protected readonly string connectionString = "Server=DESKTOP-MVISQ7G\\SQLEXPRESS;Database=SchoolManagement; TrustServerCertificate=True; Trusted_Connection=True;  Integrated Security=True; MultipleActiveResultSets=true;";
    private readonly StudentContext _studentContext;
    private readonly IMapper _mapper;
    public EnrollmentService(StudentContext studentContext, IMapper mapper)
    {
        _studentContext = studentContext;
        _mapper = mapper;
    }
    public List<EnrollmentVM> GetEnrollmentAsync()
    {
        List<EnrollmentVM> result = new();
        using (var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("GetStudentEnrolledCourses", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EnrollmentVM vm = new EnrollmentVM()
                        {
                            StudentName = reader["StudentName"].ToString(),
                            CourseName = reader["CourseName"].ToString(),
                            ClassName = reader["ClassName"].ToString(),
                            SectionName = reader["SectionName"].ToString(),
                            Marks = Convert.ToInt32(reader["Marks"]),
                            Description = reader["Description"].ToString()
                        };
                        result.Add(vm);
                    }
                }
            }
        }
        
        return result;
    }
}
