using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniDatabase
{
    public class TestClass
    {
        public static void TestOperations()
        {
            var context = new SoftUniEntities();

            Employee employee = new Employee()
            {
                FirstName = "Denis1",
                LastName = "Neychev",
                JobTitle = "Zidaro-mazach",
                DepartmentID = 1,
                ManagerID = 6,
                HireDate = DateTime.Now,
                Salary = 999
            };

            Employee.Add(employee);

            context.SaveChanges();
            
            Console.WriteLine(employee.EmployeeID);

            employee.FirstName = employee.FirstName + '.';

            Employee.Modify(employee);

            context.SaveChanges();

            Employee.Delete(employee);

            context.SaveChanges();
        }
    }
}