namespace BigMani.Models
{
    using System;
    using Core;

    public class PlaneAirConditioner : AirConditioner
    {
        private int electricityUsed;
        private int volumeCovered;

        public PlaneAirConditioner(
            string manufacturer,
            string model,
            int volumeCovered,
            int electricityUsed)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
            this.ElectricityUsed = electricityUsed;
        }

        public int VolumeCovered
        {
            get { return this.volumeCovered; }

            set
            {
                if (value <= 0)
                {
                    var message = string.Format(Messages.NegativeInteger, "Ivan");
                    throw new ArgumentException(message);
                }

                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get { return this.electricityUsed; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Messages.NegativeInteger);
                }

                this.electricityUsed = value;
            }
        }

        public override bool Test()
        {
            var sqrtVolume = Math.Sqrt(this.volumeCovered);

            if (this.ElectricityUsed/sqrtVolume < Messages.MinPlaneElectricity)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                        this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";

            print += "Volume Covered: " + this.VolumeCovered + "\r\n" + "Electricity Used: " + this.ElectricityUsed +
                     "\r\n";

            print += "====================";

            return print;
        }
    }
}