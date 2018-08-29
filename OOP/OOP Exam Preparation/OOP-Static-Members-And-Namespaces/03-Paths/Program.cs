using System;

namespace _03_Paths
{
    class Program
    {
        static void Main()
        {
            Point3D[] PointArr =
            {
                new Point3D(1,2,3),
                new Point3D(4,5,6),
                new Point3D(7,8,9) 
            };

            //Some weird thing happening here.
            Path3D SamplePath = new Path3D(PointArr);
            SamplePath.PointStorage = PointArr;

            Storage.SavePaths(SamplePath);

            string[] paths = Storage.LoadPaths().Split(';');

            foreach (string path in paths)
            {
                if (path != "")
                {
                    Console.WriteLine(String.Format("Point: {0}", path));
                }
            }
        }
    }
}
