namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;

    public abstract class Course
    {
        protected Course(string courseName, string teacherName = null, IList<string> students = null)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }
    }
}