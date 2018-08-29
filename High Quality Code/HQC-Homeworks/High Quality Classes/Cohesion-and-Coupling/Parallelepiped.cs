namespace CohesionAndCoupling
{
    public class Parallelepiped
    {
        public static double Width { get; set; }
        public static double Height { get; set; }
        public static double Depth { get; set; }


        public static double CalcVolume()
        {
            var volume = Width*Height*Depth;
            return volume;
        }

        public static double CalcDiagonalXyz()
        {
            var distance = FigureUtils.CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        public static double CalcDiagonalXy()
        {
            var distance = FigureUtils.CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public static double CalcDiagonalXz()
        {
            var distance = FigureUtils.CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public static double CalcDiagonalYz()
        {
            var distance = FigureUtils.CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}