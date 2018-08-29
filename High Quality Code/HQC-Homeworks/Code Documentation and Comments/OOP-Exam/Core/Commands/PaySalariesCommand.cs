namespace ExamPreparationCapitalism.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using Interfaces;
    using Models.Employees;
    using Models.Interfaces;

    internal class PaySalariesCommand : CommandAbstract
    {
        private readonly string companyName;
        private readonly StringBuilder output;
        private CEO ceo;

        public PaySalariesCommand(
            string companyName,
            IDatabase db) : base(db)
        {
            this.companyName = companyName;
            this.output = new StringBuilder();
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
            this.Pay(company, 0, 0);
            return this.output.ToString();
        }

        private decimal Pay(
            IOrganizationalUnit unit,
            decimal paid,
            int depth)
        {
            foreach (var dep in unit.SubUnits)
            {
                paid += this.Pay(dep, 0, depth + 1);
            }

            foreach (var emp in unit.Employees)
            {
                var percents = (15 - depth)*0.01m;
                paid += emp.RecieveSalary(percents, this.ceo.Salary);
            }

            this.output.Insert(0,
                string.Format("{0}{1} ({2:f2})\n",
                    new string(' ', depth*4),
                    unit.Name,
                    paid
                    )
                );

            return paid;
        }
    }
}