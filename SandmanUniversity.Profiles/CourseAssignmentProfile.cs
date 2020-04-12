using AutoMapper;
using SandmanUniversity.Data;
using SandmanUniversity.Models.CourseAssignments;

namespace SandmanUniversity.Profiles
{
    public class CourseAssignmentProfile : Profile
    {
        public CourseAssignmentProfile()
        {
            CreateMap<CourseAssignment, ViewModel>();
        }
    }
}