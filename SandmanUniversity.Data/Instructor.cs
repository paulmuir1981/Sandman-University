using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SandmanUniversity.Data
{
    public class Instructor
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}