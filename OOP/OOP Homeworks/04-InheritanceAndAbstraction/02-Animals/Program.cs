namespace _02_Animals
{
    internal class Program
    {
        private static void Main()
        {
            Animal[] animals =
            {
                new Cat("asd", 5, "female"),
                new Cat("asd", 5, "male"),
                new Cat("asd", 5, "female"),
                new Frog("ffdfdf", 5, "male"),
                new Frog("sdsd", 5, "male"),
                new Frog("dsdsd", 5, "male"),
                new Dog("sdsd", 10, "male"),
                new Dog("sdsd", 10, "male"),
                new Dog("sdsd", 10, "male")
            };

            foreach (var animal in animals)
            {
                animal.ProduceSound();
            }
        }
    }
}