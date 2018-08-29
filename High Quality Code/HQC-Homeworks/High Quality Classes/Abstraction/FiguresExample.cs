namespace Abstraction
{
    internal class FiguresExample
    {
        private static void Main()
        {
            var circle = new Circle(5);
            circle.PrintInfo();

            var rect = new Rectangle(-2, -3);
            rect.PrintInfo();
        }
    }
}