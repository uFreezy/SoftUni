namespace _03_CompanyHierarchy
{
    public class Manager : Employee
    {
        private Employee[] underCommand;

        public Manager(int id, string firstName, string lastName, float salary, 
                        string department, Employee[] underCommand)
                        : base(id, firstName, lastName, salary, department)
        {
            this.UnderCommand = underCommand;
        }

        public Employee[] UnderCommand
        {
            get { return this.underCommand; }
            set { this.underCommand = value; }
        }
    }
}