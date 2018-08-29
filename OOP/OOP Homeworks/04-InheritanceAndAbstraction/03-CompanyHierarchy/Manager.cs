namespace _03_CompanyHierarchy
{
    public class Manager : Employee
    {
        public Manager(int id, string firstName, string lastName, float salary,
            string department, Employee[] underCommand)
            : base(id, firstName, lastName, salary, department)
        {
            this.UnderCommand = underCommand;
        }

        public Employee[] UnderCommand { get; set; }
    }
}