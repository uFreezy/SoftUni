namespace _06_OtherTypes
{
    using System;

    public struct Location
    {
        private double _latitude;
        private double _longitude;

        public Location(double latitude, double longitude, Planet planet) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get { return this._latitude; }
            set
            {
                if (value >= -90 && value <= 90)
                {
                    this._latitude = value;
                }
                else
                {
                    throw new ArgumentException("Latitude range must be between -90.0 and 90.0.");
                }
            }
        }

        public double Longitude
        {
            get { return this._longitude; }
            set
            {
                if (value >= -180 && value <= 180)
                {
                    this._longitude = value;
                }
                else
                {
                    throw new ArgumentException("Longitude must be between -180.0 and 180.0.");
                }
            }
        }

        public Planet Planet { get; set; }

        public override string ToString()
        {
            return $"{this.Latitude}, {this.Longitude} - {this.Planet}";
        }
    }
}