namespace ExamPreparationCapitalism.Models.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    ///     The implementations of this interface represent some
    ///     kind of organisaton with it's required properties and actions.
    /// </summary>
    public interface IOrganizationalUnit
    {
        string Name { get; }

        IEnumerable<IOrganizationalUnit> SubUnits { get; }

        IEnumerable<IEmployee> Employees { get; }

        IEmployee Head { get; set; }

        /// <summary>
        ///     Adds sub-unit to the SubUnits collection.
        /// </summary>
        /// <param name="unit">Sub-unit to be added.</param>
        void AddSubUnit(IOrganizationalUnit unit);

        /// <summary>
        ///     Adds employee to the Employees collection.
        /// </summary>
        /// <param name="employee">Employee to be added.</param>
        void AddEmployee(IEmployee employee);

        /// <summary>
        ///     Removes employee from the employee collection.
        /// </summary>
        /// <param name="employee">Employee to be removed.</param>
        void RemoveEmployee(IEmployee employee);
    }
}