using System.Collections.Generic;

namespace tdkhoa_day11_lab4.Models
{
    public class Major
    {
        public Major()
        {
            Learners = new HashSet<Learner>();
        }

    public int MajorID { get; set; }

        public string MajorName { get; set; } = string.Empty;

        public virtual ICollection<Learner> Learners { get; set; }
    }


}
