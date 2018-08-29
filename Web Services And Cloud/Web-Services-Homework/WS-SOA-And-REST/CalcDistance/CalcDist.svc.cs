using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CalcDistance
{
    public class Service1 : ICalcDist
    {
        public float CalcDistance(Point sPoint, Point ePoint)
        {
            return (float)Math.Sqrt(Math.Pow(sPoint.X - ePoint.X, 2) + Math.Pow(sPoint.Y - ePoint.Y, 2));
        }
    }
}
