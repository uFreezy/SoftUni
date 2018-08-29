using System.Collections.Generic;
using System.Runtime.Versioning;
using StudentSys.Models;

namespace StudentSys.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSys.Data.StudentSysContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSys.Data.StudentSysContext";
        }

        protected override void Seed(StudentSys.Data.StudentSysContext context)
        {
            // Generates and executes 'cleanup' queries for the Identity.
            string CleanStudents = "DBCC CHECKIDENT('Students', RESEED, 0)";
            string CleanCourses = "DBCC CHECKIDENT('Courses', RESEED, 0)";

            context.Database.ExecuteSqlCommand(CleanStudents);
            context.Database.ExecuteSqlCommand(CleanCourses);

            for (int i = 0; i < 10; i++)
            {
                context.Students.AddOrUpdate(
                    s => s.Name,
                    new Student()
                    {
                        Name = "Ivan" + i,
                        Phone = "12345" + i,
                        RegisterDate = DateTime.Now,
                        Courses =  context.Courses.ToList()
                    });

              
                context.Homeworks.AddOrUpdate(
                    h => h.Content,
                    new Homework()
                    {
                        Content = "Sample text" + i,
                        ContentType = ContentType.NotSpecified,
                        SubmissionDate = DateTime.MaxValue,
                        StudentId = i + 1
                    });

                context.Resources.AddOrUpdate(
                    r => r.Name,
                    new Resource()
                    {
                        Name = "Sample text" + i,
                        ResourceType = ResourceType.Document,
                        Url = "Sample url" + i
                    });

                context.Courses.AddOrUpdate(
                  c => c.Name,
                  new Course()
                  {
                      Name = "Sample text" + i,
                      Description = "Sample text" + i,
                      StartDate = DateTime.Now,
                      EndDate = DateTime.MaxValue,
                      Price = 1,
                      Resources = context.Resources.ToList()

                  });
            }
            context.SaveChanges();
        }
    }
}
