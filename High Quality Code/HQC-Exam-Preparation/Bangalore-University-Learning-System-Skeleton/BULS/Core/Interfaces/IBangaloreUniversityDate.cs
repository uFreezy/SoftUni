namespace BangaloreUniversityLearningSystem.Core.Interfaces
{
    using Data;
    using Models;

    public interface IBangaloreUniversityDate
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}