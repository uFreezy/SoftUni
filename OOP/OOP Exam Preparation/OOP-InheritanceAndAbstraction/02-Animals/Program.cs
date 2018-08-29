using System;

namespace _02_Animals
{
    class Program
    {
        static void Main()
        {
            var kitty = new Kitten("sss",55,"female");

            Animal[] Animals =
            {
                new Cat("asd", 5, "female"),
                new Cat("asd", 5, "male"),
                new Cat("asd", 5, "female"),
                new Frog("ffdfdf",5,"male"), 
                new Frog("sdsd",5,"male"), 
                new Frog("dsdsd",5,"male"),
                new Dog("sdsd",10,"male"), 
                new Dog("sdsd",10,"male"), 
                new Dog("sdsd",10,"male"), 
            };

            Console.WriteLine(Animals[3]);
        }
    }
}
