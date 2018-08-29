namespace _01_DefiningClasses
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            //Test the person class
            var person = new Person("Ivan", 55, "dddd@");
            Console.WriteLine(person);

            //Test the laptop class
            var laptop = new Laptop("Ivan", 999, "Gosho", "bateriika", 50);
            Console.WriteLine(laptop);

            //Test the PC class
            var components = new[]
            {
                new Component("ivan", 10.50, "na ivan videoto"),
                new Component("ivan2", 10.60, "na ivan videoto"),
                new Component("ivan3", 10.70, "na ivan videoto")
            };

            var computer = new Computer("Test", components);

            computer.PrintInfo();
        }
    }
}