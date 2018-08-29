using System;

namespace Exam_prep1
{
    class WorkHours
    {
        static void Main()
        {
            int h = int.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            byte p = byte.Parse(Console.ReadLine());
            if (p > 100)
            {
                Console.WriteLine("The precentage can't be higher than 100!");
                Environment.Exit(0);
            }
            d = ((((d * 90) / 100) * 12) * p) / 100;
            d = Math.Floor(d);
            if (d - h < 0)
            {
                Console.WriteLine("No");
                Console.WriteLine("{0}",d-h);
            }
            else
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0}", d - h);
            }

        }
    }
}
