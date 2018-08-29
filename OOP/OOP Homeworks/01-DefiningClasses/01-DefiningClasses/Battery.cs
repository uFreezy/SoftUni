namespace _01_DefiningClasses
{
    using System;
    using System.Linq;

    public class Battery
    {
        private readonly string _batteryName;
        private double _batteryLife;

        public Battery(string battery, double batteryLife)
        {
            this._batteryName = battery;
            this._batteryLife = batteryLife;
        }

        public string BatteryName
        {
            get { return this._batteryName; }
            set
            {
                var isDigitsOnly = true;

                foreach (var c in value.Where(c => c < '0' || c > '9'))
                {
                    isDigitsOnly = false;
                }

                if (value == "" || isDigitsOnly)
                {
                    throw new ArgumentException("Battery name cannot contain only digits or be empty.");
                }
                this.BatteryName = value;
            }
        }

        public double BatteryLife
        {
            get { return this._batteryLife; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Battery life cannot be empty or negative.");
                }
                this._batteryLife = value;
            }
        }
    }
}