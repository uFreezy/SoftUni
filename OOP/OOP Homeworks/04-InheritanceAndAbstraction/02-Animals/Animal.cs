namespace _02_Animals
{
    using System;

    public abstract class Animal : ISoundProduceable
    {
        private int _age;
        private string _gender;
        private string _name;


        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this._name = value;
            }
        }

        public int Age
        {
            get { return this._age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative number.");
                }

                this._age = value;
            }
        }

        public virtual string Gender
        {
            get { return this._gender; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Gender cannot be empty.");
                }

                if (value.ToLower() != "female" && value.ToLower() != "male")
                {
                    throw new ArgumentException("Gender must be either \"male\" or \"female\" .");
                }

                this._gender = value;
            }
        }

        public virtual void ProduceSound()
        {
        }
    }
}