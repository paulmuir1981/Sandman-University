using AutoMapper;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Courses;

namespace SandmanUniversity.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, ViewModel>();
        }
    }
}