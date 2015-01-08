using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DrivingSchoolMVCApp.Models
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>()
            {
                new Student{FirstName = "Musa", LastName = "Zulu", Email = "musa.zulu@chillisoft.co.za", EnrollmentDate = DateTime.Parse("2015-01-02")},
                new Student{FirstName = "Musasa", LastName = "Zulus", Email = "musa.zulu@chillisoft.co.za",EnrollmentDate = DateTime.Parse("2014-12-28")},
            };

            foreach (var temp in students)
            {
                context.Students.Add(temp);
            }
            context.SaveChanges();

            var courses = new List<Course>()
            {
                new Course{Title = "Java",Credits = 16},
                new Course {Title = "C#", Credits = 8}
            };

            foreach (var temp in courses)
            {
                context.Courses.Add(temp);
            }
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentId = 1, CourseId = 1, Grade = 3},
                new Enrollment {StudentId = 1, CourseId = 2, Grade = 4}
            };

            foreach (var temp in enrollments)
            {
                context.Enrollments.Add(temp);
            }
            context.SaveChanges();
        }
    }
}