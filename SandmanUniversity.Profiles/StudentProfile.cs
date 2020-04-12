using AutoMapper;
using SandmanUniversity.Commands.Students;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Students;
using System;
using System.Linq;

namespace SandmanUniversity.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, ViewModel>();
            CreateMap<Student, DetailsViewModel>();
            CreateMap<Student, CreateEditViewModel>();
            CreateMap<Student, DeleteViewModel>();
            CreateMap<CreateEditViewModel, CreateEditCommand>();
            CreateMap<DeleteViewModel, DeleteCommand>();
            CreateMap<IGrouping<DateTime, Student>, EnrollmentDateViewModel>()
                .ForMember(model => model.EnrollmentDate, conf => conf.MapFrom(grouping => grouping.Key));
        }
    }
}