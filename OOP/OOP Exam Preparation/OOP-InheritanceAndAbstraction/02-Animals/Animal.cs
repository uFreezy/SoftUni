using System;

public abstract class Animal : ISoundProduceable
{
    private string name;
    private int age;
    private string gender;

    
    protected Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (String.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age cannot be negative number.");
            }

            this.age = value;
        }
    }

    public virtual string Gender
    {
        get { return this.gender; }
        set
        {
            if (String.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentException("Gender cannot be empty.");
            }

            if (value.ToLower() != "female" && value.ToLower() != "male")
            {
                throw new ArgumentException("Gender must be either \"male\" or \"female\" .");
            }

            this.gender = value;
        }
    }

    public virtual void ProduceSound()
    {
    }
}
//Create an abstract class Animal holding name, age and gender.