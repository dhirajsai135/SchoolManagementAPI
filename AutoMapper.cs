namespace SchoolManagementAPI;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Student,StudentVM>();
        CreateMap<Enrollment,EnrollmentVM>();
        CreateMap<Course,CourseVM>();
        CreateMap<Class,ClassVM>();
    }
}
