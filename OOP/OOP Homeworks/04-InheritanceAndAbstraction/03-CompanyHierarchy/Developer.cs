namespace _03_CompanyHierarchy
{
    public class Developer : Employee
    {
        public Developer(int id, string firstName, string lastName,
            float salary, string department, Projects[] setOfProjectses)
            : base(id, firstName, lastName, salary, department)
        {
            this.SetOfProjects = setOfProjectses;
        }

        public Projects[] SetOfProjects { get; set; }
    }
}