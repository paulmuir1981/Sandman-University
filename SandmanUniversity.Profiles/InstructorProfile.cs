using AutoMapper;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Instructors;

namespace SandmanUniversity.Profiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor, ViewModel>();
        }
    }
}