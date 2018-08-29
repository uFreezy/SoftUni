namespace CodeFormatting
{
    using System;

    internal class WorkHoursReformatted
    {
        private static void Main()
        {
            var requiredHours = int.Parse(Console.ReadLine());
            var daysAvailable = double.Parse(Console.ReadLine());
            var productivityPercentage = byte.Parse(Console.ReadLine());

            if (productivityPercentage > 100)
            {
                Console.WriteLine("The precentage can't be higher than 100!");
                Environment.Exit(0);
            }

            daysAvailable = ( ( ( (daysAvailable * 90) / 100 ) * 12 ) * productivityPercentage) / 100;
            daysAvailable = Math.Floor(daysAvailable);

            if (daysAvailable - requiredHours < 0)
            {
                Console.WriteLine("No");
                Console.WriteLine("{0}", daysAvailable - requiredHours);
            }
            else
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0}", daysAvailable - requiredHours);
            }
        }
    }
}