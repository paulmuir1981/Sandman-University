﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SandmanUniversity.Data
{
    public class Student
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}