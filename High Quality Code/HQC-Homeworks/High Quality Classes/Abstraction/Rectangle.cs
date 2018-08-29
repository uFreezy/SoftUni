namespace Abstraction
{
    using System;
    using Interfaces;

    internal class Rectangle : IFigureCalculateble
    {
        private double _height;
        private double _width;

        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("Width and height must be positive numbers.");
            }

            this._width = width;
            this._height = height;
        }

        public double Width
        {
            get { return this._width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width must be a positive number.");
                }

                this._width = value;
            }
        }

        public double Height
        {
            get { return this._height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be a positive number.");
                }

                this._height = value;
            }
        }

        public double CalcPerimeter()
        {
            var perimeter = 2*(this.Width + this.Height);
            return perimeter;
        }

        public double CalcSurface()
        {
            var surface = this.Width*this.Height;
            return surface;
        }

        public void PrintInfo()
        {
            Console.WriteLine("I am a circle. " +
                              "My perimeter is {0:f2}. My surface is {1:f2}.",
                this.CalcPerimeter(), this.CalcSurface());
        }
    }
}