using ATM.Data.Migrations;
using ATM.Models;

namespace ATM.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ATMContext : DbContext
    {

        public ATMContext()
            : base("ATMContext")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMContext, Configuration>());
        }

        public virtual DbSet<CardAccount> CardAccounts { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }
    }


}