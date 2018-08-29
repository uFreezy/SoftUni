namespace _03_CompanyHierarchy
{
    public class RegularEmployee : Employee
    {
        public RegularEmployee(int id, string firstName, string lastName, float salary, string department)
            : base(id,firstName,lastName,salary,department)
        {
        }
    }
}