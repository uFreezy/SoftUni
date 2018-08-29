namespace _01_HumanStudentAndWorker
{
    using System;

    public class Worker : Human
    {
        private float _weekSalary;
        private float _workHoursPerDay;

        public Worker()
        {
        }

        public Worker(string firstName, string lastName, float weekSalary, float workHoursPerDay)
            : base(firstName, lastName)
        {
            this._weekSalary = weekSalary;
            this._workHoursPerDay = workHoursPerDay;
        }

        public float WeekSalary
        {
            get { return this._weekSalary; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Week salary cannot be zero or negative.");
                }
                this._weekSalary = value;
            }
        }

        public float WorkHoursPerDay
        {
            get { return this._workHoursPerDay; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Work hours cannot be zero or negative.");
                }
                this._workHoursPerDay = value;
            }
        }

        public float MoneyPerHour()
        {
            return this._weekSalary/(this._workHoursPerDay*7);
        }
    }
}