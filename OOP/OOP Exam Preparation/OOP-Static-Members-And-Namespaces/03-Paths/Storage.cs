using System;
using System.IO;

public static class Storage
{
    public static void SavePaths(Path3D Points)
    {
        string line = "";

        foreach (Point3D Point in Points.PointStorage)
        {
            line += Point.X.ToString() + ',' + Point.Y.ToString() + ',' + Point.Z.ToString() + ';';
        }

        System.IO.File.WriteAllText(@"E:\Programming\OOP\text.txt", line);
    }

    public static string LoadPaths()
    {
        using (StreamReader sr = new StreamReader(@"E:\Programming\OOP\text.txt"))
        {
            String line = sr.ReadToEnd();
            return line;
        }
    }
}
