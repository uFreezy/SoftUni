using System;
using System.Collections.Generic;
using System.Data.Entity;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public class OnlineShopData : IOnlineShopData
    {
        private readonly DbContext _context;
        private readonly IDictionary<Type, object> _repositories;

        public OnlineShopData(DbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users => GetRepository<ApplicationUser>();

        public IRepository<Ad> Ads => GetRepository<Ad>();

        public IRepository<AdType> AdTypes => GetRepository<AdType>();

        public IRepository<Category> Categories => GetRepository<Category>();

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
            if (!_repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof (GenericRepository<T>);
                var repository = Activator.CreateInstance(
                    typeOfRepository, _context);

                _repositories.Add(type, repository);
            }

            return (IRepository<T>) _repositories[type];
        }
    }
}