using System;

namespace _03_CompanyHierarchy
{
    public class Sale
    {
        private string name;
        private DateTime date;
        private float price;

        public Sale(string name, DateTime date, float price)
        {
            this.Name = name;
            this.Date = date;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public DateTime Date
        {
            get { return this.date; }
            set
            {
                try
                {
                    this.date = value;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine("Invalid date! ");
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
            get { return this.price; }
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