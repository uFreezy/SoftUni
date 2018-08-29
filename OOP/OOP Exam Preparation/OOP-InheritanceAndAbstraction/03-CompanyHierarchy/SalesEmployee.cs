using System.CodeDom;

namespace _03_CompanyHierarchy
{
    public class SalesEmployee : Employee
    {
        private Sale[] salesSet;

        public SalesEmployee(int id, string firstName, string lastName, float salary, 
                             string department, Sale[] salesSet)
                            : base(id, firstName, lastName, salary, department)
        {
            this.SalesSet = salesSet;
        }

        public Sale[] SalesSet
        {
            get { return this.salesSet; }
            set { this.salesSet = value; }
        }
    }
}
//holds a set of sales. A sale holds product name, date and price.