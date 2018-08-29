using System;

namespace _03_CompanyHierarchy
{
    public class Projects
    {
        private string name;
        private DateTime date;
        private string details;
        private bool isOpen = true;

        public Projects(string name, DateTime date, string details)
        {
            this.Name = name;
            this.Details = details;
            this.date = date;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new  ArgumentException("Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public DateTime StartDate
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Details cannot be empty.");
                }

                this.details = value;
            }
        }

        public void CloseProject()
        {
            this.isOpen = false;
            Console.WriteLine("Project is now closed...");
        }

    }
}

//A project holds project name, project start date, details and a state (open or closed). 
//A project can be closed through the method CloseProject().A project holds project name, 
//project start date, details and a state (open or closed). A project can be closed through 
//the method CloseProject().