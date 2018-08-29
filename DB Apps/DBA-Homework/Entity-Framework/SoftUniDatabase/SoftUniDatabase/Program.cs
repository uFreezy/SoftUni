using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace SoftUniDatabase
{
    internal class Program
    {
        private static void Main()
        {
            //Problem 1
            var context = new SoftUniEntities();

            //Problem 2
            TestClass.TestOperations();

            //Problem 3.1

            var employees = context.Employees.Where(e => e.Projects
                .Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Projects = e.Projects
                        .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
                        .Select(p => new
                        {
                            p.Name,
                            p.StartDate,
                            p.EndDate
                        }),
                    ManagerName = e.Employee1.FirstName + " " + e.Employee1.LastName
                });

            foreach (var employee in employees)
            {
                Console.WriteLine("Name: {0} {1}", employee.FirstName, employee.LastName);
                Console.WriteLine("\tManager: {0}", employee.ManagerName);
                Console.WriteLine("\tProjects:");
                foreach (var project in employee.Projects)
                {
                    Console.WriteLine("\t\tProject Name: {0}\n\t\tStart Date:" +
                                      " {1}\n\t\tEnd Date{2}\n",
                        project.Name,
                        project.StartDate,
                        project.EndDate);
                }
            }

            //Problem 3.2

            var addresses = context.Addresses.Select(a => new
            {
                Address = a.AddressText,
                a.Town.Name,
                NumberOfEmployees = a.Employees.Count()

            }).OrderByDescending(a => a.NumberOfEmployees).ThenBy(a => a.Name).Take(10);

            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2}",
                    address.Address,
                    address.Name,
                    address.NumberOfEmployees);
            }

            //Problem 3.3

            var emp = context.Employees.Where(e => e.EmployeeID == 1).Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.Projects
            });

            foreach (var e in emp)
            {
                string prj = "";
                foreach (var proj in e.Projects)
                {
                    prj += proj.Name + "\n ";
                }
                Console.WriteLine("First Name: {0}\nLast Name: {1}\nJob Title: {2}\nProjects: {3}",
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    prj);
            }

            ////Problem 3.4

            var deps = context.Departments.Where(d => d.Employees.Count > 5).Select(d => new
            {
                d.Name,
                Manager = context.Employees.Where(e => e.EmployeeID == d.ManagerID).Select(e => new { e.LastName }),
                Employees = context.Employees.Where(em => em.DepartmentID == d.DepartmentID).Select(em => new
                {
                    em.FirstName,
                    em.LastName,
                    em.HireDate,
                    em.JobTitle
                })

            }).OrderBy(d => d.Employees.Count());

            foreach (var dep in deps)
            {
                string Man = "";
                foreach (var m in dep.Manager)
                {
                    Man = m.LastName;
                }

                Console.WriteLine("-- {0} - Manager: {1}, Employees: {2}",
                    dep.Name,
                    Man,
                    dep.Employees.ToList().Count()
                    );
            }

            // Problem 4.1

            string NativeQuery =
                "SELECT e.FirstName FROM employees e " +
                "INNER JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID " +
                "INNER JOIN Projects p ON ep.ProjectID = p.ProjectID";

            var names = context.Database.SqlQuery<string>(NativeQuery).ToList();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            //Problem 4.2 

            //Find all employees who have projects with start date in the year 2002. Select only their first name. 

            var EmpPr = context.Employees.Where(e => e.Projects
                .Any(p => p.StartDate.Year == 2002))
                .Select(e => e.FirstName);

            foreach (var empl in EmpPr)
            {
                Console.WriteLine(empl);
            }

            //Problem 5
            var context2 = new SoftUniEntities();

            var Cont1Change = context.Employees.Find(1).FirstName = "gosho2";
            var Cont2Change = context2.Employees.Find(1).FirstName = "ivan3";

            // When the concurency control is changed to fixed it goes boom.
            context.SaveChanges();
           // context2.SaveChanges();

            //Problem 6

            var ProjectsList = context.usp_Projects4Employee("Roberto", "Tamburello");

            foreach (var project in ProjectsList)
            {
                Console.WriteLine("Name: {0}\nDescription: {1}\nStarting Date: {2}\n",
                    project.Name,
                    project.Description,
                    project.StartDate);
               
            }
        }
    }
}