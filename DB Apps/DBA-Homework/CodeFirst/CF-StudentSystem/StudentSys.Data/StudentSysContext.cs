using StudentSys.Data.Migrations;
using StudentSys.Models;

namespace StudentSys.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSysContext : DbContext
    {
        public StudentSysContext()
            : base("StudentSysContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSysContext, Configuration>());
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Student> Students { get; set; }

    }

}