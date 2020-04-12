using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SandmanUniversity.Models.Instructors
{
    public class ViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Office")]
        public string OfficeAssignmentLocation { get; set; }

        public List<CourseAssignments.ViewModel> CourseAssignments { get; set; }
    }
}