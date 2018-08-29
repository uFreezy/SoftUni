namespace BigMani.Models
{
    using System;
    using System.Linq;
    using Core;

    public class StationaryAirConditioner : AirConditioner
    {
        private char energyRating;
        private int powerUsage;

        public StationaryAirConditioner(string manufacturer, string model, char energyRating, int powerUsage)
            : base(manufacturer, model)
        {
            this.EnergyEfficiencyRating = energyRating;
            this.PowerUsage = powerUsage;
        }

        public char EnergyEfficiencyRating
        {
            get { return this.energyRating; }

            set
            {
                var possibleVals = new[] {'A', 'B', 'C', 'D', 'E'};

                if (possibleVals.Contains(value))
                {
                    this.energyRating = value;
                }

                else
                {
                    throw new ArgumentException(Messages.IncorrectRating);
                }
            }
        }

        public int PowerUsage
        {
            get { return this.powerUsage; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Messages.NegativeInteger);
                }
                this.powerUsage = value;
            }
        }

        public override bool Test()
        {
            //TODO: extract values into enum?
            bool passedTest;

            switch (this.EnergyEfficiencyRating)
            {
                case 'A':
                    passedTest = this.powerUsage < 1000;
                    break;
                case 'B':
                    passedTest = this.powerUsage >= 1000 && this.powerUsage <= 1250;
                    break;
                case 'C':
                    passedTest = this.powerUsage >= 1251 && this.powerUsage <= 1500;
                    break;
                case 'D':
                    passedTest = this.powerUsage >= 1501 && this.powerUsage <= 2000;
                    break;
                case 'E':
                    passedTest = this.powerUsage > 2000;
                    break;
                default:
                    passedTest = false;
                    break;
            }

            return passedTest;
        }

        public override string ToString()
        {
            var print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                        this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";
            var energy = this.EnergyEfficiencyRating;

            print += "Required energy efficiency rating: " + energy + "\r\n" + "Power Usage(KW / h): " +
                     this.PowerUsage + "\r\n";
            print += "====================";

            return print;
        }
    }
}