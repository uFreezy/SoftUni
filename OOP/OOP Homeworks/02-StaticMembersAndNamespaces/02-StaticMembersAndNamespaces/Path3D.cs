namespace _02_StaticMembersAndNamespaces
{
    public class Path3D
    {
        public Path3D(Point3D[] points)
        {
            this.Path = points;
        }

        public Point3D[] Path { get; set; }
    }
}