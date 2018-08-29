namespace Abstraction.Interfaces
{
    /// <summary>
    ///     Provides common method for calculations
    ///     over some kind of figure.
    /// </summary>
    public interface IFigureCalculateble
    {
        /// <summary>
        ///     Calculates figure's perimeter.
        /// </summary>
        /// <returns>Figure's perimeter</returns>
        double CalcPerimeter();

        /// <summary>
        ///     Calculates figure's surface.
        /// </summary>
        /// <returns>Figure's surface.</returns>
        double CalcSurface();

        /// <summary>
        ///     Prints given info about the figure.
        /// </summary>
        void PrintInfo();
    }
}