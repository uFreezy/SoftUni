using System;
using System.Net;

namespace CalcDistanceREST.Client
{
    internal class CalcDistanceRest
    {
        private static void Main()
        {
            Console.Write("Point 1:\nX:");
            var startX = int.Parse(Console.ReadLine());
            Console.Write("Y:");
            var startY = int.Parse(Console.ReadLine());

            Console.Write("Point 2:\nX:");
            var endX = int.Parse(Console.ReadLine());
            Console.Write("Y:");
            var endY = int.Parse(Console.ReadLine());

            var client = new WebClient();

            var result = client.DownloadString("http://localhost:62474/api/points?startX=" +
                                               +startX + "&startY=" + startY + "&endX=" + endX + "&endY=" + endY);

            Console.WriteLine(result);
        }
    }
}