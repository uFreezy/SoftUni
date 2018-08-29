using System;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization.Formatters;

namespace SoftUniDatabase
{
    public partial class Employee
    {
        public static void Add(Employee employee)
        {
            var context = new SoftUniEntities();

            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            var context = new SoftUniEntities();

            return context.Employees.Find(key);
        }

        public static void Modify(Employee employee)
        {
            var context = new SoftUniEntities();

            Employee EmpModify = context.Employees.Find(employee.EmployeeID);

            context.Entry(EmpModify).CurrentValues.SetValues(employee);

           context.SaveChanges();
        }

        public static void Delete(Employee employee)
        {
            var context = new SoftUniEntities();

            var entry = context.Entry(employee);

            if (entry.State == EntityState.Detached)
            {
                context.Employees.Attach(employee);
            }
               
            context.Employees.Remove(employee);
            
            context.SaveChanges();
        }
    }
}