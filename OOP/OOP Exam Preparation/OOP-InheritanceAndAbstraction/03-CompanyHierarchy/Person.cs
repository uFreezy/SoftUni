using System;

namespace _03_CompanyHierarchy
{
    public class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        public Person(int id, string firstName, string lastName)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int ID
        {
            get { return this.id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id cannot be 0 or negative.");
                }
                this.id = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Last name cannot be empty");
                }
                this.lastName = value;
            }
        }
    }
}