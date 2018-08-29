namespace _03_CompanyHierarchy
{
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main()
        {
            var employees = new List<object>
            {
                new SalesEmployee(1, "Pesho", "Goshev", 44, "sales", new Sale[1]),
                new SalesEmployee(1, "2Pesho", "Goshev", 44, "sales", new Sale[1]),
                new SalesEmployee(1, "3Pesho", "Goshev", 44, "sales", new Sale[1]),
                new Developer(1, "Ivan", "Goshev", 44, "sales", new Projects[1]),
                new Developer(1, "2Ivan", "Goshev", 44, "sales", new Projects[1]),
                new Developer(1, "3Ivan", "Goshev", 44, "sales", new Projects[1])
            };
        }
    }
}