using System;

public class Person
{
    private string name;
    private int age;
    private string email;

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
        get { return this.name; }
        set
        {
            if (String.IsNullOrEmpty(value)) throw new ArgumentException("Name cannot be empty");
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if(value < 1 || value > 100) throw new ArgumentException("Age must be value between 1 and 100");
            this.age = value;
        }
    }

    public string Email
    {
        get { return this.email; }
        set
        {
            if(String.IsNullOrEmpty(value) || value.IndexOf('@') == -1) 
                throw new ArgumentException("Email cannot be empty and it must contain '@'");
            this.email = value;
        }
    }

    public override string ToString()
    {
        return string.Format("Name: {0}\nAge: {1}\nEmail: {2}", this.name, this.age, this.email);
    }
}
