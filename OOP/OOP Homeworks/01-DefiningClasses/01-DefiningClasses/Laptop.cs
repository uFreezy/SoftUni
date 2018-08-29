namespace _01_DefiningClasses
{
    using System;

    public sealed class Laptop
    {
        private string _gpu;
        private string _hdd;
        private string _manufactuer;
        private string _model;
        private double _price;
        private string _processor;
        private string _ram;
        private string _screen;


        public Laptop(string model,
            double price,
            string processor = null,
            string batteryName = null,
            double batteryLife = 0,
            string manufactuer = null,
            string ram = null,
            string gCard = null,
            string hdd = null,
            string screen = null)
        {
            this.Model = model;
            this.Manufacturer = manufactuer;
            this.Processor = processor;
            this.Ram = ram;
            this.Gpu = gCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = new Battery(batteryName, batteryLife);
            this.Price = price;
        }

        public string Model
        {
            get { return this._model; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Model cannot be empty");
                }
                this._model = value;
            }
        }

        public double Price
        {
            get { return this._price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be a positive number.");
                }
                this._price = value;
            }
        }

        public string Manufacturer { get; set; }

        public string Processor { get; set; }

        public string Ram { get; set; }

        public string Gpu { get; set; }

        public string Hdd { get; set; }

        public string Screen { get; set; }

        public Battery Battery { get; set; }


        public override string ToString()
        {
            string result = $" Model: {this._model} \n Price: {this._price} \n ";

            if (this._manufactuer != null)
            {
                result += $"Manufactuer: {this._manufactuer} \n ";
            }

            if (this._processor != null)
            {
                result += $"Processor: {this._processor} \n ";
            }

            if (this.Battery.BatteryName != null && this.Battery.BatteryLife != 0)
            {
                result += $"Battery name: {this.Battery.BatteryName} \n Battery life: {this.Battery.BatteryLife} \n ";
            }

            if (this._ram != null)
            {
                result += $"RAM: {this._ram} \n ";
            }

            if (this._gpu != null)
            {
                result += $"Graphics card: {this._gpu} \n ";
            }

            if (this._hdd != null)
            {
                result += $"HDD: {this._hdd} \n ";
            }

            if (this._screen != null)
            {
                result += $"Screen: {this._screen} \n ";
            }

            return result;
        }
    }
}