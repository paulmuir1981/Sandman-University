using System.ComponentModel.DataAnnotations;

namespace SandmanUniversity.Data
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorId { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        public Instructor Instructor { get; set; }
    }
}