namespace _03_CompanyHierarchy
{
    using System;

    public class Projects
    {
        private string _details;
        private bool _isOpen = true;
        private string _name;

        public Projects(string name, DateTime date, string details)
        {
            this.Name = name;
            this.Details = details;
            this.StartDate = date;
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                this._name = value;
            }
        }

        public DateTime StartDate { get; set; }

        public string Details
        {
            get { return this._details; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Details cannot be empty.");
                }

                this._details = value;
            }
        }

        public void CloseProject()
        {
            this._isOpen = false;
            Console.WriteLine("Project is now closed...");
        }
    }
}