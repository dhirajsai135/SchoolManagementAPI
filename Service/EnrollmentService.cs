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
    public async  Task<List<EnrollmentVM>> GetAllAsync()
    {
        if (_studentContext == null)
        {
            return new List<EnrollmentVM>();
        }
        var response = await _studentContext.Enrollments.ToListAsync();
        return _mapper.Map<List<EnrollmentVM>>(response);
    }
    
    public async Task<EnrollmentVM> GetAsync(int enrollmentId)
    {
        EnrollmentVM enrollment = new();
        if (_studentContext == null)
        {
            return enrollment;
        }
        var response = await _studentContext.Enrollments.FindAsync(enrollmentId);
        if (response == null)
        {
            return enrollment;
        }
        var result = _mapper.Map<EnrollmentVM>(response);
        return result;
    }

    public async Task<bool> SaveAsync(Enrollment enrollment)
    {
        if (enrollment == null) { return false; }
        await _studentContext.Enrollments.AddAsync(enrollment);
        await _studentContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int enrollmentId)
    {
        var enrollment = await _studentContext.Enrollments.FindAsync(enrollmentId);
        if (_studentContext == null)
        {
            return false;
        }
        if (enrollment == null)
        {
            return false;
        }
        _studentContext.Enrollments.Remove(enrollment);
        await _studentContext.SaveChangesAsync();
        return true;
    }

    public List<StudentEnrollmentsVM> GetEnrollmentBasedOnStudentsAsync()
    {
        List<StudentEnrollmentsVM> result = new();
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
                        StudentEnrollmentsVM vm = new StudentEnrollmentsVM()
                        {
                            StudentName = reader["StudentName"].ToString() ?? string.Empty,
                            CourseName = reader["CourseName"].ToString() ?? string.Empty,
                            ClassName = reader["ClassName"].ToString() ?? string.Empty,
                            SectionName = reader["SectionName"].ToString() ?? string.Empty,
                            Marks = Convert.ToInt32(reader["Marks"]),
                            Description = reader["Description"].ToString() ?? string.Empty
                        };
                        result.Add(vm);
                    }
                }
            }
        }

        return result;
    }

}
