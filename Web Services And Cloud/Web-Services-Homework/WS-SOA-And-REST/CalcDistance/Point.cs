using System.Runtime.Serialization;

namespace CalcDistance
{
    [DataContract]
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }
    }
}