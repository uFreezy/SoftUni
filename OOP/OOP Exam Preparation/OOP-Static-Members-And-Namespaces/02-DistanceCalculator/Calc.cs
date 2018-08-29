using System;

public static class Calc
{
    public static float CalcDistance(Point3D p1, Point3D p2)
    {
        float deltaX = p2.X - p1.X;
        float deltaY = p2.Y - p1.Y;
        float deltaZ = p2.Z - p1.Z;

        float result = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

        return result;
    }
}

//float deltaX = x1 - x0;
//float deltaY = y1 - y0;
//float deltaZ = z1 - z0;

//float distance = (float) Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);