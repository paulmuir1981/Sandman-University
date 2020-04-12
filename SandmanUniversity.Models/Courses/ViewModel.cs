using System.ComponentModel.DataAnnotations;

namespace SandmanUniversity.Models.Courses
{
    public class ViewModel
    {
        [Display(Name = "Number")]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}
