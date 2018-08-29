namespace ExamPreparationCapitalism
{
    using Core;
    using Core.Engines;
    using Interfaces;

    internal class Program
    {
        private static void Main(string[] args)
        {
            IDatabase db = new Database();
            IEngine engine = new ConsoleCapitalismEngine(db);
            engine.Run();
        }
    }
}