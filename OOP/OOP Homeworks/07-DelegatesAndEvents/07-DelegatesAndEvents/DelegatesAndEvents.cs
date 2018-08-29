namespace _07_DelegatesAndEvents
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class DelegatesAndEvents
    {
        private static void Main()
        {
            //01-CustomLINQExtensionMethods

            var numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var filterList = numbers.WhereNot(n => n == 5);

            foreach (var numb in filterList)
            {
                //Console.WriteLine(numb);
            }

            //02-InterestCalculator
            var smipleInterestCalc = new InterestCalculator(2500, 7.2, 15, GetSimpleInterest);

            var compoundInterestCalc = new InterestCalculator(500, 5.6, 10, GetCompoundInterest);


            //Console.WriteLine(smipleInterestCalc);
            //Console.WriteLine(compoundInterestCalc);

            //03-AsynchronousTimer
            var asyncTimer = new AsyncTimer(Console.WriteLine, 1000, 100, "Hello world!");
            // asyncTimer.Run();

            for (var i = 0; i < 1000; i++)
            {
                //This is done for testing purposes of the worker in the separate thread.
                //Console.WriteLine();
                //Thread.Sleep(500);
            }


            //04-StudentClass

            var student = new Student("Ivan petrov", 100);

            Thread.Sleep(5000);
            student.Age = 15;
        }

        //02-InterestCalculator
        public static double GetSimpleInterest(double sum, double interest, int years)
        {
            return sum*(1 + interest/100*years);
        }

        public static double GetCompoundInterest(double sum, double interest, int years)
        {
            return sum*Math.Pow(1 + interest/100/12, years*12);
        }
    }
}