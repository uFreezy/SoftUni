namespace ExamPreparationCapitalism.Models.OrganizationalUnits
{
    using System.Collections.Generic;
    using Interfaces;

    public class Company : IOrganizationalUnit
    {
        private readonly IList<IEmployee> employees;
        private readonly IList<IOrganizationalUnit> subUnits;

        public Company(string name)
        {
            this.subUnits = new List<IOrganizationalUnit>();
            this.employees = new List<IEmployee>();
            this.AllEmployees = new List<IEmployee>();
            this.AllDepartments = new List<IOrganizationalUnit>();
            this.Name = name;
        }

        public IList<IOrganizationalUnit> AllDepartments { get; }

        public IList<IEmployee> AllEmployees { get; }

        public string Name { get; }

        public IEnumerable<IOrganizationalUnit> SubUnits
        {
            get { return this.subUnits; }
        }


        public IEnumerable<IEmployee> Employees
        {
            get { return this.employees; }
        }

        public IEmployee Head { get; set; }

        public void AddSubUnit(IOrganizationalUnit unit)
        {
            this.subUnits.Add(unit);
        }

        public void AddEmployee(IEmployee employee)
        {
            this.employees.Add(employee);
        }

        public void RemoveEmployee(IEmployee employee)
        {
            this.employees.Remove(employee);
        }
    }
}