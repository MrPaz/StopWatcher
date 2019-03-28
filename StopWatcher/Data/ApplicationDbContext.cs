using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StopWatcher.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Exchange> Exchange { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Position> OpenOrders { get; set; }
        public DbSet<StopOrders> StopOrders { get; set; }
    }
}
