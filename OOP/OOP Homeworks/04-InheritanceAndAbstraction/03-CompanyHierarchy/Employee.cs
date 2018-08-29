namespace _03_CompanyHierarchy
{
    using System;

    public class Employee : Person, IEmployee
    {
        private string _department;
        private float _salary;

        public Employee(int id, string firstName, string lastName, float salary, string department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public float Salary
        {
            get { return this._salary; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Salary cannot be 0 or negative");
                }

                this._salary = value;
            }
        }

        public string Department
        {
            get { return this._department; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Department cannot be empty");
                }

                if (value.Trim().ToLower() == "production" || value.Trim().ToLower() == "accounting" ||
                    value.Trim().ToLower() == "sales" || value.Trim().ToLower() == "marketing")
                {
                    this._department = value;
                }
                else
                {
                    throw new ArgumentException("Invalid _department!");
                }
            }
        }
    }
}