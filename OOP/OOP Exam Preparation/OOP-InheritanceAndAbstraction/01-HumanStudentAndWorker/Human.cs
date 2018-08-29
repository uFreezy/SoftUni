using System;

public abstract class Human
{
    private string firstName;
    private string lastName;

    public Human()
    {
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName 
    {
        get { return this.firstName; }
        set
        {
            if (String.IsNullOrEmpty(value.Trim()))
            {
                throw new ArgumentException("Name cannot be empty.");
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
                throw new ArgumentException("Name cannot be empty.");
            }
            this.lastName = value;
        }
    }

}