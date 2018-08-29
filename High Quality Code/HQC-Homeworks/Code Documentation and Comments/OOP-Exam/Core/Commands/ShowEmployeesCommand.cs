namespace ExamPreparationCapitalism.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using Interfaces;
    using Models.Employees;
    using Models.Interfaces;

    internal class ShowEmployeesCommand : CommandAbstract
    {
        private readonly string companyName;
        private CEO ceo;
        private StringBuilder output;

        public ShowEmployeesCommand(
            string companyName,
            IDatabase db) : base(db)
        {
            this.companyName = companyName;
        }

        public override string Execute()
        {
            var company = this.db.Companies.FirstOrDefault(c => c.Name == this.companyName);
            if (company == null)
            {
                throw new ArgumentException(
                    string.Format("Company {0} does not exist", this.companyName));
            }
            this.ceo = (CEO) company.Head;
            this.PrintHierarchy(company, 0);
            return "";
        }

        private void PrintHierarchy(IOrganizationalUnit unit, int depth)
        {
            Console.WriteLine("{0}({1})", new string(' ', depth*4), unit.Name);
            foreach (var employee in unit.Employees)
            {
                Console.WriteLine("{0}{1} {2} ({3:f2})", new string(' ', depth*4), employee.FirstName, employee.LastName,
                    employee.TotalPaid);
            }
            foreach (var subUnit in unit.SubUnits)
            {
                this.PrintHierarchy(subUnit, depth + 1);
            }
        }
    }
}