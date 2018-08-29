namespace _01_HumanStudentAndWorker
{
    using System;

    public abstract class Human
    {
        private string _firstName;
        private string _lastName;

        protected Human()
        {
        }

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return this._firstName; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Name cannot be empty.");
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
                    throw new ArgumentException("Name cannot be empty.");
                }
                this._lastName = value;
            }
        }
    }
}