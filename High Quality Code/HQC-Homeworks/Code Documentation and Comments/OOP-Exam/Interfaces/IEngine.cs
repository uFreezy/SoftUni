namespace ExamPreparationCapitalism.Interfaces
{
    /// <summary>
    ///     The inheritors of this interface implement the
    ///     basic requirements for a engine to function.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        ///     The implementation of this method is used by
        ///     the inheritors to start their engine loop.
        /// </summary>
        void Run();
    }
}