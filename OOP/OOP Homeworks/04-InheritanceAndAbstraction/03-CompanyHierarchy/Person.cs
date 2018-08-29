namespace _03_CompanyHierarchy
{
    using System;

    public class Person : IPerson
    {
        private string _firstName;
        private int _id;
        private string _lastName;

        public Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id
        {
            get { return this._id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id cannot be 0 or negative.");
                }
                this._id = value;
            }
        }

        public string FirstName
        {
            get { return this._firstName; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this._firstName = value;
            }
        }

        public string LastName
        {
            get { return this._lastName; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Last name cannot be empty");
                }
                this._lastName = value;
            }
        }
    }
}