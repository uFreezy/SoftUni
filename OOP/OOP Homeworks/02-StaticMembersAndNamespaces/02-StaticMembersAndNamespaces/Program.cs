namespace _02_StaticMembersAndNamespaces
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            //Printing point.
            Console.WriteLine(new Point3D(5, 6, 5));

            //Distance calc.
            var pointA = new Point3D(1, 2, 3);
            var pointB = new Point3D(3, 4, 5);

            Console.WriteLine(DistanceCalculator.Distance(pointA, pointB));

            //Path
            var path = new Path3D(new[] {pointA, pointB});

            Storage.SavePath(path);

            Storage.LoadPaths();
        }
    }
}