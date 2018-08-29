using System;

namespace _02_DistanceCalculator
{
    class Program
    {
        static void Main()
        {
            Point3D Point1 = new Point3D(9, 13, 2);
            Point3D Point2 = new Point3D(5, 10, 8);

            Console.WriteLine(Calc.CalcDistance(Point1, Point2));
        }
    }
}
