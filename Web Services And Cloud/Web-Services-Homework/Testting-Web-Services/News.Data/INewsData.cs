namespace News.Data
{
    public interface INewsData
    {
        IRepository<Models.News> News { get; }

        int SaveChanges();

    }
}