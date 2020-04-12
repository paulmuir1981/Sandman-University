using System.ComponentModel.DataAnnotations;

namespace SandmanUniversity.Models.Enrollments
{
    public class ViewModel
    {
        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public string Grade { get; set; }
    }
}