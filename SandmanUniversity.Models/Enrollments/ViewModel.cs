using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SandmanUniversity.Models.Enrollments
{
    public class ViewModel
    {
        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public string Grade { get; set; }
        public string StudentLastName { get; set; }
        public string StudentFirstName { get; set; }
        [JsonIgnore]
        public string StudentFullName => StudentLastName + ", " + StudentFirstName;
    }
}