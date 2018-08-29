using System;

namespace _03_CompanyHierarchy
{
    public class Employee : Person, IEmployee
    {
        private float salary;
        private string department;

        public Employee(int id, string firstName, string lastName, float salary, string department) 
            : base(id,firstName,lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public float Salary
        {
            get { return this.salary; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Salary cannot be 0 or negative");
                }

                this.salary = value;
            }
        }

        public string Department
        {
            get { return this.department; }
            set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Department cannot be empty");
                }

                if (value.Trim().ToLower() == "production" || value.Trim().ToLower() == "accounting" ||
                    value.Trim().ToLower() == "sales" || value.Trim().ToLower() == "marketing")
                {
                    this.department = value;
                }
                else
                {
                    throw new ArgumentException("Invalid department!");
                }
            }
        }
    }
}