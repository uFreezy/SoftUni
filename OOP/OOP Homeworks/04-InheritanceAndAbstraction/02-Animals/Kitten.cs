namespace _02_Animals
{
    using System;

    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override string Gender
        {
            get { return base.Gender; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Gender cannot be empty.");
                }

                if (value.ToLower().Trim() != "female")
                {
                    throw new ArgumentException("Kittens are always FEMALE. Please enter proper gender.");
                }
                base.Gender = value;
            }
        }
    }
}