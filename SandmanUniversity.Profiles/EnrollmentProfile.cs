using AutoMapper;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Enrollments;

namespace SandmanUniversity.Profiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, ViewModel>();
        }
    }
}