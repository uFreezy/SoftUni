namespace BigMani
{
    using Core;
    using UI;

    public class Program
    {
        public static void Main()
        {
            var engine = new Engine(new ConsoleUserInterface());
            engine.Run();
        }
    }
}