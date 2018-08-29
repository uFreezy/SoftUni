using System;

namespace OOP_Static_Members_And_Namespaces
{
    class Program
    {
        static void Main()
        {
            Point3D Point = new Point3D(5,10,8);

            Console.WriteLine(Point);
            Console.WriteLine(Point3D.StartingPoint);
        }
    }
}
