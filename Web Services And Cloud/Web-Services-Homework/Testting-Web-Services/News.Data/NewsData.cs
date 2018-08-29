using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace News.Data
{
    public class NewsData : INewsData
    {
        private readonly DbContext _context;
        private readonly IDictionary<Type, object> _repositories;

        public NewsData(DbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<Models.News> News => GetRepository<Models.News>();

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public int SaveChangesAsync()
        {
            return _context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof (T);
            if (_repositories.ContainsKey(type)) return (IRepository<T>) _repositories[type];
            var typeOfRepository = typeof (GenericRepository<T>);
            var repository = Activator.CreateInstance(
                typeOfRepository, _context);

            _repositories.Add(type, repository);

            return (IRepository<T>) _repositories[type];
        }
    }
}