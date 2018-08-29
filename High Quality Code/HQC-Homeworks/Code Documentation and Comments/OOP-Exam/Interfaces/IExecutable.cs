namespace ExamPreparationCapitalism.Interfaces
{
    /// <summary>
    ///     The inheritors of this interface can be executed.
    /// </summary>
    public interface IExecutable
    {
        /// <summary>
        ///     The method is used for execution of some
        ///     action implemented by the inheritors.
        /// </summary>
        /// <returns></returns>
        string Execute();
    }
}