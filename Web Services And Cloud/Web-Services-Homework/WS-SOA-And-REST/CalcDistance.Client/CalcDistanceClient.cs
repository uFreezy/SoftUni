using System;
using CalcDistance.Client.CalcDist;

namespace CalcDistance.Client
{
    internal class CalcDistanceClient
    {
        private static void Main()
        {
            var instance = new CalcDistClient();

            Console.Write("Point 1:\nX:");
            var sPoint = new CalcDist.Point();
            sPoint.X = int.Parse(Console.ReadLine());
            Console.Write("Y:");
            sPoint.Y = int.Parse(Console.ReadLine());

            Console.Write("Point 2:\nX:");
            var ePoint = new CalcDist.Point();
            ePoint.X = int.Parse(Console.ReadLine());
            Console.Write("Y:");
            ePoint.Y = int.Parse(Console.ReadLine());

            Console.WriteLine(instance.CalcDistance(sPoint, ePoint));
        }
    }
}