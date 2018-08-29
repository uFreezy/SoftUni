namespace ExamPreparationCapitalism.Models.Employees
{
    using Interfaces;

    public class Accountant : Employee
    {
        private const decimal SalaryFactorDefault = 0;

        public Accountant(string firstName, string lastName, IOrganizationalUnit inUnit)
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}