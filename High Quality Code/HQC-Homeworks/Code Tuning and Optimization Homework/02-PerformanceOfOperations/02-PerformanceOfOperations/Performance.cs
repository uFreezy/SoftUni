namespace _02_PerformanceOfOperations
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    internal class Performance
    {
        private static void Main()
        {
            var testInt = 0;
            long testLong = 0;
            float testFloat = 0;
            double testDouble = 0;
            decimal testDecimal = 0;

            TestIntPerformance(testInt);
            TestLongPerformance(testLong);


            // Write a program to compare the performance of add, subtract, 
            // increment, multiply, divide for int, long, float, double and decimal values.
        }

        private static void TestIntPerformance(int var)
        {
            var time = new Stopwatch();
            
            time.Start();
            var += 1000000;           
            Console.WriteLine("Integer += 1000000 || Time elapsed = {0} ticks", time.ElapsedTicks);
            time.Reset();

            time.Start();
            var -= 5000000;      
            Console.WriteLine("Integer -= 5000000 || Time elapsed = {0} ticks", time.ElapsedTicks);
            time.Reset();

            time.Start();
            var++;
            Console.WriteLine("Integer incremented. || Time elapsed = {0} ticks", time.ElapsedTicks);
            time.Reset();

            time.Start();
            var *= 100000;
            Console.WriteLine("Integer *= 100000 || Time elapsed = {0} ticks", time.ElapsedTicks);
            time.Reset();

            time.Start();
            var /= 50000;
            Console.WriteLine("Integer /= 50000 || Time elapsed = {0} ticks", time.ElapsedTicks);
            time.Reset();
        }

        private static void TestLongPerformance(long var)
        {
            var time = new Stopwatch();

            time.Start();
            var += 1000000;
            Console.WriteLine("Long += 1000000 || Time elapsed = {0} ticks", time.ElapsedTicks);
            time.Reset();

            time.Start();
            var -= 5000000;
            Console.WriteLine("Long -= 5000000 || Time elapsed = {0} ticks", time.ElapsedTicks);
            time.Reset();

            time.Start();
            var++;
            Console.WriteLine("Long incremented. || Time elapsed = {0} ticks", time.ElapsedTicks);
            time.Reset();

            time.Start();
            var *= 100000;
            Console.WriteLine("Long *= 100000 || Time elapsed = {0} ticks", time.ElapsedTicks);
            time.Reset();

            time.Start();
            var /= 50000;
            Console.WriteLine("Long /= 50000 || Time elapsed = {0} ticks", time.ElapsedTicks);
            time.Reset();
        }
    }
}