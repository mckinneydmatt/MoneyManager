using MoneyManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class MoneyManagerDbContext : DbContext
    {
        public MoneyManagerDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<CheckingAcct> CheckingAccts { get; set; }
        public DbSet<SavingsAcct> SavingsAccts { get; set; }
        public DbSet<RetirementAcct> RetirementAccts { get; set; }
        public DbSet<Expense> Expenses { get; set; }

    }
}
