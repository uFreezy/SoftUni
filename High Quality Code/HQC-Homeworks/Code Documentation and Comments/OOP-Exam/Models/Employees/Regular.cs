﻿namespace ExamPreparationCapitalism.Models.Employees
{
    using Interfaces;

    public class Regular : Employee
    {
        private const decimal SalaryFactorDefault = 0;

        public Regular(string firstName, string lastName, IOrganizationalUnit inUnit)
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}