namespace _03_CompanyHierarchy
{
    public class SalesEmployee : Employee
    {
        public SalesEmployee(int id, string firstName, string lastName, float salary,
            string department, Sale[] salesSet)
            : base(id, firstName, lastName, salary, department)
        {
            this.SalesSet = salesSet;
        }

        public Sale[] SalesSet { get; set; }
    }
}