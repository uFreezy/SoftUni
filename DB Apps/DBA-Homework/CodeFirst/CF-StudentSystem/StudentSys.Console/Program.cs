using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSys.Data;
using StudentSys.Models;

namespace StudentSys.Console
{
    class Program
    {
        static void Main()
        {
            var context = new StudentSysContext();

            var Students = context.Students;

            foreach (var student in Students)
            {
                System.Console.WriteLine(student.Name);
            }

            //Problem 3.1

            var StudentsAndHomeworks = context.Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = context.Homeworks
                    .Where(h => h.Student.Name == s.Name)
                    .Select(h => new
                    {
                        h.Content,
                        h.ContentType
                    }).ToList()
                });

            foreach (var student in StudentsAndHomeworks)
            {
                string homeworks = "";

	            foreach (var homework in student.Homeworks)
	            {
	                homeworks += "\n " + homework.Content + " " + homework.ContentType;
	            }

                System.Console.WriteLine("Student: {0}\nHomeworks: {1}",
                    student.Name,
                    homeworks);
            }

            //Problem 3.2

            var CoursesResources = context.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    Resources = c.Resources.ToList()
                });

            foreach (var course in CoursesResources)
            {
                string resources = course.Resources.Aggregate("", (current, resource) => current + (" \n   " + resource.Name + "\n   " + resource.ResourceType + "\n   " + resource.Url));

                System.Console.WriteLine("Course name: {0}\nCourse description: {1}\nResources: {2}",
                    course.Name,
                    course.Description,
                    resources);
            }

            //Problem 3.3

            var MoreThan5 = context.Courses
                .Where(c => c.Resources.ToList().Count > 5)
                .OrderByDescending(c => c.Resources
                    .ToList()
                    .Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    ResourceCount = c.Resources.ToList().Count
                });


            foreach (var course in MoreThan5)
            {
                System.Console.WriteLine("Course name: {0}\nResource count: {1}",
                    course.Name,
                    course.ResourceCount);
            }

            //Problem 3.4

            var Courses = context.Courses
                .Where(c => c.StartDate >= DateTime.MinValue && c.EndDate <= DateTime.MaxValue)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    CourseDuration = DbFunctions.DiffDays(c.StartDate,c.EndDate) + "days",
                    EnrolledStudents = c.Students.ToList().Count
                })
                .OrderByDescending(c => c.EnrolledStudents)
                .ThenByDescending(c => c.CourseDuration);

            foreach (var course in Courses)
            {
                System.Console.WriteLine("Name: {0}\nStart Date: {1}\n" +
                                         "End Date: {2}\nCourse Duration: {3}\n" +
                                         "Enrolled Students: {4}",
                                         course.Name,
                                         course.StartDate,
                                         course.EndDate,
                                         course.CourseDuration,
                                         course.EnrolledStudents
                                         );
            }

            //Problem 3.5

            var StudentsInfo = context.Students
                .Select(s => new {
                    s.Name,
                    s.Courses.ToList().Count,
                    TotalPrice = (s.Courses.ToList().Count > 0) ? 
                                  s.Courses.Sum(c => c.Price) : 0,
                    AveragePrice = (s.Courses.ToList().Count > 0) ? 
                                    s.Courses.Sum(c => c.Price) / s.Courses.ToList().Count : 0
                })
                .OrderByDescending(c => c.TotalPrice)
                .ThenByDescending(s => s.Count)
                .ThenBy(s => s.Name);

            foreach (var student in StudentsInfo)
            {
                System.Console.WriteLine("Name: {0}\nNumber Of Courses: {1}\n" +
                                         "Total Price: {2}\nAverage Price: {3}",
                                         student.Name,
                                         student.Count,
                                         student.TotalPrice,
                                         student.AveragePrice
                                         );
            }

            
        }
    }
}
