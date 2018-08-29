﻿namespace ExamPreparationCapitalism.Models.Employees
{
    using Interfaces;

    public class Salesman : Employee
    {
        private const decimal SalaryFactorDefault = 0.015m;

        public Salesman(string firstName, string lastName, IOrganizationalUnit inUnit)
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}