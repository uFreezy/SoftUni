using System;

public class Worker : Human
{
    private float weekSalary;
    private float workHoursPerDay;

    public Worker()
    {
    }
    public Worker(string firstName, string lastName, float weekSalary, float workHoursPerDay)
        : base(firstName, lastName)
    {
        this.weekSalary = weekSalary;
        this.workHoursPerDay = workHoursPerDay;
    }

    public float WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Week salary cannot be zero or negative.");
            }
            this.weekSalary = value;
        }
    }

    public float WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Work hours cannot be zero or negative.");
            }
            this.workHoursPerDay = value;
        }
    }

    public float MoneyPerHour()
    {
        return this.weekSalary/(this.workHoursPerDay*7);
    }
}