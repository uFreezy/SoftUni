namespace Abstraction
{
    using System;
    using Interfaces;

    internal class Circle : IFigureCalculateble
    {
        private double _radius;

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius must be a positive number.");
            }

            this._radius = radius;
        }

        public double Radius
        {
            get { return this._radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius must be a positive number.");
                }

                this._radius = value;
            }
        }

        public double CalcPerimeter()
        {
            var perimeter = 2*Math.PI*this.Radius;
            return perimeter;
        }

        public double CalcSurface()
        {
            var surface = Math.PI*this.Radius*this.Radius;
            return surface;
        }

        public void PrintInfo()
        {
            Console.WriteLine("I am a rectangle. " +
                              "My perimeter is {0:f2}. My surface is {1:f2}.",
                this.CalcPerimeter(), this.CalcSurface());
        }
    }
}