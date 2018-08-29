using System;

namespace _03_PcCatalog
{
    class Program
    {
        static void Main()
        {
            Component[] CompArr =
            {
                new Component("Gosho", 99.85),
                new Component("Gosho2", 99.85, "Sample description.2"),
                new Component("Gosho3", 99.85, "Sample description.3")
            };

            Console.WriteLine(new Computer("My PC", CompArr, 150));

        }
    }
}
