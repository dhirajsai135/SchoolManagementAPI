namespace SchoolManagementAPI;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<Student,StudentVM>();
    }
}
