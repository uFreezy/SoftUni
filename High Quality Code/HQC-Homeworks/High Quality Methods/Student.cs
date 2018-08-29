namespace Methods
{
    using System;
    using System.Globalization;

    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentBio { get; set; }

        public bool IsOlderThan(Student other)
        {
            var studentBirthDate = this.StudentBio
                .Substring(this.StudentBio.Length - 10);

            var firstDate =
                DateTime.ParseExact(studentBirthDate, "dd.mm.yyyy",CultureInfo.InvariantCulture);
            var secondDate =
                DateTime.ParseExact(studentBirthDate, "dd.mm.yyyy", CultureInfo.InvariantCulture);

            var isOlderThan = firstDate > secondDate;

            return isOlderThan;
        }
    }
}