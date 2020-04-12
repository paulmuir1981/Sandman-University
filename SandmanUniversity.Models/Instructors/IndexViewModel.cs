using System.Collections.Generic;

namespace SandmanUniversity.Models.Instructors
{
    public class IndexViewModel
    {
        public IEnumerable<ViewModel> Instructors { get; set; }
        public IEnumerable<Courses.ViewModel> Courses { get; set; }
        public IEnumerable<Enrollments.ViewModel> Enrollments { get; set; }
        public int? InstructorId { get; set; }
        public int? CourseId { get; set; }
    }
}