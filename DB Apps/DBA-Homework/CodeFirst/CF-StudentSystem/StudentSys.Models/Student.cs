using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace StudentSys.Models
{
    public class Student
    {
        private ICollection<Course> courses; 

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

       //Students: id, name, phone number (optional), registration date, birthday (optional) 
    }
}