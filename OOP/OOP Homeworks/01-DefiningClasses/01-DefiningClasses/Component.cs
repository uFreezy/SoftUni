namespace _01_DefiningClasses
{
    using System;

    public class Component
    {
        private string _name;
        private double _price;

        public Component(string name, double price, string details = null)
        {
            this.Name = name;
            this.Details = details;
            this.Price = price;
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Component name cannot be empty!");
                }
                this._name = value;
            }
        }

        public string Details { get; set; }

        public double Price
        {
            get { return this._price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Component price must be a positive number!");
                }
                this._price = value;
            }
        }
    }
}