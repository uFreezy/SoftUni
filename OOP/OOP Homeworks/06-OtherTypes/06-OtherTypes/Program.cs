namespace _06_OtherTypes
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            //01-GalacticGPS
            var home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);

            //02-FractionCalculator
            var fraction1 = new Fraction(22, 7);
            var fraction2 = new Fraction(40, 4);
            var result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);

            //03-GenericList
            var list = new GenericList<int>();
            list.Add(5);
            Console.WriteLine(list[0]);
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Remove(1);

            Console.WriteLine(list[1]);

            var newList = new GenericList<int>();

            for (var i = 0; i < 5000; i++)
            {
                newList.Add(i);
                //Console.WriteLine(newList[i]);
            }

            //newList.Clear();
            //Console.WriteLine(newList[1]);

            var id = newList.FindIndex(8);

            Console.WriteLine("Id found: " + id);

            Console.WriteLine(newList);

            newList.GetAttribute();
        }
    }
}