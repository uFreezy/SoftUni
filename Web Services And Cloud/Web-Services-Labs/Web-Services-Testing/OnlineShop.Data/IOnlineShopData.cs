using System.Data.Entity;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public interface IOnlineShopData
    {
        IRepository<Ad> Ads { get; }

        IRepository<AdType> AdTypes { get; }

        IRepository<Category> Categories { get; }

        IRepository<ApplicationUser> Users { get; } 

        int SaveChanges();
    }
}