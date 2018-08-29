using System.Data;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Data.Migrations;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OnlineShopContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineShopContext()
            : base("name=OnlineShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineShopContext, Configuration>());
        }

        public static OnlineShopContext Create()
        {
            return new OnlineShopContext();
        }

        public virtual DbSet<Ad> Ads { get; set; }

        public virtual DbSet<AdType> AdTypes { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
    }
}