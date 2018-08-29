namespace ExamPreparationCapitalism.Interfaces
{
    using System.Collections.Generic;
    using Models.Interfaces;

    /// <summary>
    ///     The implementation of this interface holds
    ///     Database consisting of companies collection
    ///     and some actions which can be performed on it.
    /// </summary>
    public interface IDatabase
    {
        IEnumerable<IOrganizationalUnit> Companies { get; }

        /// <summary>
        ///     The method adds company to the collection.
        /// </summary>
        /// <param name="company">The company to be added.</param>
        void AddCompany(IOrganizationalUnit company);
    }
}