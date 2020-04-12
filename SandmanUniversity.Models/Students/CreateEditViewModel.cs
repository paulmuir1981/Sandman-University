using System;
using System.ComponentModel.DataAnnotations;

namespace SandmanUniversity.Models.Students
{
    public class CreateEditViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters.", MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name must be between 1 and 50 characters.", MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime? EnrollmentDate { get; set; }
    }
}
