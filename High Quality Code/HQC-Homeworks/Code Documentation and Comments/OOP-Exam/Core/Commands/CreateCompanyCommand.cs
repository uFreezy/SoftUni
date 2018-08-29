namespace ExamPreparationCapitalism.Core.Commands
{
    using System;
    using Factories;
    using Interfaces;
    using Models.Interfaces;
    using Models.OrganizationalUnits;

    public class CreateCompanyCommand : CommandAbstract
    {
        private readonly string ceoFirstName;
        private readonly string ceoLastName;
        private readonly decimal ceoSalary;
        private readonly string companyName;

        public CreateCompanyCommand(
            IDatabase db,
            string companyName,
            string ceoFirstName,
            string ceoLastName,
            decimal ceoSalary
            )
            : base(db)
        {
            this.companyName = companyName;
            this.ceoFirstName = ceoFirstName;
            this.ceoLastName = ceoLastName;
            this.ceoSalary = ceoSalary;
        }

        public override string Execute()
        {
            foreach (var c 
                in this.db.Companies)
            {
                if (c.Name == this.companyName)
                {
                    throw new Exception(string.Format("Company {0} already exists", this.companyName));
                }
            }

            IOrganizationalUnit company = new Company(this.companyName);
            var ceo = EmployeeFactory.Create(this.ceoFirstName, this.ceoLastName, "CEO", company, this.ceoSalary);
            this.db.AddCompany(company);
            company.AddEmployee(ceo);
            company.Head = ceo;
            return "";
        }
    }
}