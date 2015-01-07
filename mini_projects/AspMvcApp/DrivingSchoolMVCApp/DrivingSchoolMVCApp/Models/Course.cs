using System.Collections.Generic;

namespace DrivingSchoolMVCApp.Models
{
    public class Course
    {
        public int CorseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
