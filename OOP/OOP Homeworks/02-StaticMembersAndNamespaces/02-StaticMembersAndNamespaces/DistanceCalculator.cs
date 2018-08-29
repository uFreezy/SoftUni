namespace _02_StaticMembersAndNamespaces
{
    using System;

    public static class DistanceCalculator
    {
        public static float Distance(Point3D a, Point3D b)
        {
            var deltaX = a.X - b.X;
            var deltaY = a.Y - b.Y;
            var deltaZ = a.Z - b.Z;

            return (float) Math.Sqrt(deltaX*deltaX + deltaY*deltaY + deltaZ*deltaZ);
        }
    }
}