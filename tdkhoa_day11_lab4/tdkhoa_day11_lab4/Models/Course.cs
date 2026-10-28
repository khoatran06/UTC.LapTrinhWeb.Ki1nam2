using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace tdkhoa_day11_lab4.Models
{
    public class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }


}
