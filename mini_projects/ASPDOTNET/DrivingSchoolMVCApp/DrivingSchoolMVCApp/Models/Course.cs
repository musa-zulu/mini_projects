﻿using System.Collections.Generic;

namespace DrivingSchoolMVCApp.Models
{
    public class Course
    {
        public int  CourseId { get; set; }
        public string Title { get; set; }
        public decimal Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}