namespace BigMani.Models
{
    using System;
    using Core;

    public class CarAirConditioner : AirConditioner
    {
        private int volumeCovered;

        public CarAirConditioner(string manufacturer, string model, int volumeCoverage)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCoverage;
            //type = "car";
        }

        public int VolumeCovered
        {
            get { return this.volumeCovered; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Messages.NegativeInteger);
                }

                this.volumeCovered = value;
            }
        }

        public override bool Test()
        {
            var sqrtVolume = Math.Sqrt(this.volumeCovered);

            if (sqrtVolume < 3)
            {
                return true;
            }

            //BUG: was 2 correct = 0;
            return false;
        }

        public override string ToString()
        {
            var print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                        this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";

            print += "Volume Covered: " + this.VolumeCovered + "\r\n";

            print += "====================";

            return print;
        }
    }
}