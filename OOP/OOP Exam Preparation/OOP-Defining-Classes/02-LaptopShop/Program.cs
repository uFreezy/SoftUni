using System;

namespace _02_LaptopShop
{
    class Program
    {
        static void Main()
        {
            var gosho = new Laptop("gosho", 999, "procesorche", "bateriika", 50);
            Console.WriteLine(gosho);
        }
    }
}
