using System;

public class Student : Human
{
    private string facultyNumber;

    public Student()
    {
    }
    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        this.facultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Faculty number must be between 5 and 10 symbols");
            }
            this.facultyNumber = value;
        }
    }

}