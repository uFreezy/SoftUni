using System.ServiceModel;

namespace CalcDistance
{
    [ServiceContract]
    public interface ICalcDist
    {
        [OperationContract]
        float CalcDistance(Point sPoint, Point ePoint);
    }
}