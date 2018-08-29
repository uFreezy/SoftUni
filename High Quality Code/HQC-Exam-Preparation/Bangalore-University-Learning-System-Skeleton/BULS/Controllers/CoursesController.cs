namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Core.Exceptions;
    using Core.Interfaces;
    using Models;
    using Utilities;

    internal class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            return this.View(this.Data.Courses.GetAll()
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);

            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (false)
            {
                //TODO: Not authorized.
            }

            if (!this.Data.Courses.Get(courseId).Students.Contains(this.User))
            {
                throw new ArgumentException("You are not enrolled in this course.");
            }

            if (this.Data.Courses.Get(courseId) == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            return this.View(course);
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            ////BUG: It was set to throw exception if the role 
            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }

            var c = new Course(name);
            this.Data.Courses.Add(c);
            return this.View(c);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }

            var c = this.CourseGetter(courseId);
            c.AddLecture(new Lecture(lectureName));
            return this.View(c);
        }

        ////BUG: id should be courseId.
        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.Data.Courses.Get(courseId);

            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.AddStudent(this.User);
            return this.View(course);
        }

        private Course CourseGetter(int cId)
        {
            var course = this.Data.Courses.Get(cId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", cId));
            }

            return course;
        }
    }
}