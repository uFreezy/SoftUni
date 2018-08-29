namespace BigMani.Models
{
    using System;
    using Core;

    public abstract class AirConditioner
    {
        private string manufacturer;
        private string model;

        protected AirConditioner(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }

            set
            {
                //BUG
                if (value.Length < 2)
                {
                    throw new ArgumentException(string.Format(Messages.IncorrectPropertyLength, "Manufacturer", 4));
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get { return this.model; }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Messages.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(Messages.IncorrectPropertyLength, "Model", 2));
                }

                this.model = value;
            }
        }

        public abstract bool Test();

        public abstract override string ToString();
    }
}