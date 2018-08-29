using System.Data.Entity;
using Ajax.Data.Migrations;
using Ajax.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ajax.Data
{
    public class AjaxContext : IdentityDbContext<ApplicationUser>
    {
        public AjaxContext()
            : base("AjaxContext", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AjaxContext, Configuration>("AjaxContext"));
        }

        public virtual IDbSet<City> Cities { get; set; }

        public static AjaxContext Create()
        {
            return new AjaxContext();
        }
    }
}