namespace _01_DefiningClasses
{
    using System;

    public class Person
    {
        private int _age;
        private string _email;
        private string _name;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    throw new ArgumentException("Name cannot be empty!");
                }

                this._name = value;
            }
        }

        public int Age
        {
            get { return this._age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value must be a positive number.");
                }

                this._age = value;
            }
        }

        public string Email
        {
            get { return this._email; }
            set
            {
                if (value == null || value.Contains("@"))
                {
                    this._email = value;
                }

                else
                {
                    throw new ArgumentException("Invalid email! ");
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {this._name}\nAge: {this._age}\nEmail: {this._email}";
        }
    }
}