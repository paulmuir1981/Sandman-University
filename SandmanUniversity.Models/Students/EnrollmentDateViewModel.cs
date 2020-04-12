using System;
using System.ComponentModel.DataAnnotations;

namespace SandmanUniversity.Models.Students
{
    public class EnrollmentDateViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Student Count")]
        public int Count { get; set; }
    }
}