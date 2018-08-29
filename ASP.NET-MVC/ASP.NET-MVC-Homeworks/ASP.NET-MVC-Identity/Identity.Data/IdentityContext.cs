using System.Data.Entity;
using Identity.Data.Migrations;
using Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Data
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("IdentityContext", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IdentityContext, Configuration>("IdentityContext"));
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}