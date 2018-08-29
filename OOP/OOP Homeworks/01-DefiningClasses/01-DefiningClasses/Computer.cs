namespace _01_DefiningClasses
{
    using System;
    using System.Linq;

    public class Computer
    {
        private string _name;

        public Computer(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public Computer(string name, Component[] components)
        {
            this.Name = name;
            this.Price = components.Sum(comp => comp.Price);
            this.Components = components;
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Computer's name cannot be empty!");
                }
                this._name = value;
            }
        }

        public Component[] Components { get; set; }

        public double Price { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("Computer name: {0}", this.Name);
            foreach (var comp in this.Components)
            {
                Console.WriteLine("Component name: {0}", comp.Name);
                Console.WriteLine("Component price: {0}", comp.Price);
            }

            Console.WriteLine("Computer price: {0}", this.Price);
        }
    }
}