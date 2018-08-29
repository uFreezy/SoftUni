using System;
using System.Collections.Generic;

namespace _03_CompanyHierarchy
{
    class Program
    {
        static void Main()
        {
            List<object> Employees = new List<object>();
            Employees.Add(new SalesEmployee(1, "Pesho", "Goshev", 44, "sales", new Sale[1]));
            Employees.Add(new SalesEmployee(1, "2Pesho", "Goshev", 44, "sales", new Sale[1]));
            Employees.Add(new SalesEmployee(1, "3Pesho", "Goshev", 44, "sales", new Sale[1]));
            Employees.Add(new Developer(1, "Ivan", "Goshev", 44, "sales", new Projects[1]));
            Employees.Add(new Developer(1, "2Ivan", "Goshev", 44, "sales", new Projects[1]));
            Employees.Add(new Developer(1, "3Ivan", "Goshev", 44, "sales", new Projects[1]));
        }
    }
}
