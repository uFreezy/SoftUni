namespace CohesionAndCoupling
{
    using System;

    internal class UtilsExamples
    {
        private static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                FigureUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                FigureUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Parallelepiped.Width = 3;
            Parallelepiped.Height = 4;
            Parallelepiped.Depth = 5;

            Console.WriteLine("Volume = {0:f2}", Parallelepiped.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Parallelepiped.CalcDiagonalXyz());
            Console.WriteLine("Diagonal XY = {0:f2}", Parallelepiped.CalcDiagonalXy());
            Console.WriteLine("Diagonal XZ = {0:f2}", Parallelepiped.CalcDiagonalXz());
            Console.WriteLine("Diagonal YZ = {0:f2}", Parallelepiped.CalcDiagonalYz());
        }
    }
}