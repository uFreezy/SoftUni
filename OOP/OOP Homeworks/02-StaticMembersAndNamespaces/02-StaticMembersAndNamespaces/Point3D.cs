namespace _02_StaticMembersAndNamespaces
{
    public class Point3D
    {
        public Point3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public static Point3D StartingPoint { get; } = new Point3D(0, 0, 0);

        public override string ToString()
        {
            return $"X: {this.X}\nY: {this.Y}\nZ: {this.Z}";
        }
    }
}