using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SandmanUniversity.Models.Students
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        public List<Enrollments.ViewModel> Enrollments { get; set; }
    }
}