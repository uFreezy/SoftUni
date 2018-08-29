namespace ExamPreparationCapitalism.Models.OrganizationalUnits
{
    using System.Collections.Generic;
    using Interfaces;

    public class Department : IOrganizationalUnit
    {
        private readonly IList<IEmployee> employees;
        private readonly IList<IOrganizationalUnit> subUnits;

        public Department(string name)
        {
            this.subUnits = new List<IOrganizationalUnit>();
            this.employees = new List<IEmployee>();
            this.Name = name;
        }

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