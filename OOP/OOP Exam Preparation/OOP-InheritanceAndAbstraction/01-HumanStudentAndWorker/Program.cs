using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_HumanStudentAndWorker
{
    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            List<Worker> workers = new List<Worker>();
            List<Human> people = new List<Human>();

            students.Add(new Student() { FirstName = "ssssss", LastName = "Ivanov", FacultyNumber = "1asdasdasd" });
            students.Add(new Student() { FirstName = "Gosdasdaho6", LastName = "Ivanov", FacultyNumber = "6asdasdasd" });
            students.Add(new Student() { FirstName = "Gosgfhgho2", LastName = "Ivanov", FacultyNumber = "7asdasdasd" });
            students.Add(new Student() { FirstName = "Goshfgeo3", LastName = "Ivanov", FacultyNumber = "2asdasdasd" });
            students.Add(new Student() { FirstName = "Gosho", LastName = "Ivanov", FacultyNumber = "3asdasdasd" });
            students.Add(new Student() { FirstName = "Goserwrho", LastName = "Ivanov", FacultyNumber = "11asdassd" });
            students.Add(new Student() { FirstName = "Goswerwho", LastName = "Ivanov", FacultyNumber = "2asdasdasd" });
            students.Add(new Student() { FirstName = "Gosho", LastName = "Ivanov", FacultyNumber = "a8sdasdasd" });
            students.Add(new Student() { FirstName = "Gowerwsho", LastName = "Ivanov", FacultyNumber = "zasd9asd" });
            students.Add(new Student() { FirstName = "Gorwrwsho", LastName = "Ivanov", FacultyNumber = "asdasdasd" });

            workers.Add(new Worker() { FirstName = "1Gosho", LastName = "Petrov", WeekSalary = 1000, WorkHoursPerDay = 12 });
            workers.Add(new Worker() { FirstName = "0Gosho", LastName = "Petrov", WeekSalary = 2000, WorkHoursPerDay = 5 });
            workers.Add(new Worker() { FirstName = "2Gosho", LastName = "Petrov", WeekSalary = 3000, WorkHoursPerDay = 23 });
            workers.Add(new Worker() { FirstName = "3Gosho", LastName = "Petrov", WeekSalary = 4000, WorkHoursPerDay = 78 });
            workers.Add(new Worker() { FirstName = "4Gosho", LastName = "Petrov", WeekSalary = 5000, WorkHoursPerDay = 1231 });
            workers.Add(new Worker() { FirstName = "5Gosho", LastName = "Petrov", WeekSalary = 6000, WorkHoursPerDay = 44 });
            workers.Add(new Worker() { FirstName = "6Gosho", LastName = "Petrov", WeekSalary = 7000, WorkHoursPerDay = 33 });
            workers.Add(new Worker() { FirstName = "7Gosho", LastName = "Petrov", WeekSalary = 8000, WorkHoursPerDay = 22 });
            workers.Add(new Worker() { FirstName = "1234Gosho", LastName = "Petrov", WeekSalary = 9000, WorkHoursPerDay = 545 });
            workers.Add(new Worker() { FirstName = "G22222osho", LastName = "Petrov", WeekSalary = 10000, WorkHoursPerDay = 13 });

            students.ForEach(student => people.Add(student));
            workers.ForEach(worker=> people.Add((worker)));

            var SortedStudents = students.OrderBy(Student => Student.FacultyNumber).ToList();

            foreach (Student Student in SortedStudents)
            {
                Console.WriteLine(Student.FacultyNumber);
            }

            var SortedWorkers = workers.OrderByDescending(Worker => Worker.MoneyPerHour());

            foreach (Worker worker in SortedWorkers)
            {
                Console.WriteLine(worker.MoneyPerHour());
            }

            var SortedPeople = people.OrderBy(Human => Human.FirstName).ThenBy(Human => Human.LastName);

            foreach (Human Human in SortedPeople)
            {
                Console.WriteLine(Human.FirstName);
            }

        }
    }
}

