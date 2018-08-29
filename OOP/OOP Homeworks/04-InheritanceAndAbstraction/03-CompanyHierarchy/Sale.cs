namespace _03_CompanyHierarchy
{
    using System;

    public class Sale
    {
        private DateTime _date;
        private string _name;
        private float _price;

        public Sale(string name, DateTime date, float price)
        {
            this.Name = name;
            this.Date = date;
            this.Price = price;
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                this._name = value;
            }
        }

        public DateTime Date
        {
            get { return this._date; }
            set
            {
                try
                {
                    this._date = value;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine("Invalid _date! ");
                    throw ex;
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Something else went wrong!");
                    throw ex;
                }
            }
        }

        public float Price
        {
            get { return this._price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative or zero.");
                }
            }
        }
    }
}