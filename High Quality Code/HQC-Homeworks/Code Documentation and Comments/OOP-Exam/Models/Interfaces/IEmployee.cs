namespace ExamPreparationCapitalism.Models.Interfaces
{
    /// <summary>
    ///     Implementations of this interface hold the
    ///     basic properties and actions for an employee.
    /// </summary>
    public interface IEmployee
    {
        string FirstName { get; }
        string LastName { get; }
        IOrganizationalUnit InUnit { get; set; }
        decimal SalaryFactor { get; }
        decimal TotalPaid { get; set; }

        /// <summary>
        ///     Pays the employee's salary.
        /// </summary>
        /// <param name="percents">
        ///     The percents of the CEO salary which the
        ///     employee receives as his own salary.
        /// </param>
        /// <param name="ceoSalary">The CEO salary.</param>
        /// <returns>The employee's salary.</returns>
        decimal RecieveSalary(decimal percents, decimal ceoSalary);
    }
}