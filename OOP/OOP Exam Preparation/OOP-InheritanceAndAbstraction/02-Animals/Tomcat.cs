using System;

public class Tomcat : Cat
{
    public Tomcat(string name, int age, string gender)
        : base(name,age,gender)
    {
    }

    public override string Gender
    {
        get { return base.Gender; }
        set
        {
            if (String.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentException("Gender cannot be empty.");
            }

            if (value.ToLower().Trim() != "male")
            {
                throw new ArgumentException("Kittens are always MALE. Please enter proper gender.");
            }
            base.Gender = value;
        }
    }
}
