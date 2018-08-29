namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException("First name cannot be null or empty.");
            }

            if (lastName == null)
            {
                throw new ArgumentNullException("Last name cannot be null or empty.");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Exam> Exams { get; set; }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null || this.Exams.Count == 0)
            {
                throw new ArgumentNullException("There are no exams to check.");
            }

            return this.Exams.Select(t => t.Check()).ToList();
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams == null || this.Exams.Count == 0)
            {
                // Cannot calculate average on missing exams
                throw new ArgumentNullException("There are no exams to calculate average results on.");
            }

            var examScore = new double[this.Exams.Count];
            var examResults = this.CheckExams();

            for (var i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double) examResults[i].Grade - examResults[i].MinGrade)/
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}