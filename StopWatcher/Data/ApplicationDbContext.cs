using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StopWatcher.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<OpenOrder> OpenOrders { get; set; }
        public DbSet<StopOrder> StopOrders { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<BTCPaymentAddresses> BTCPaymentAddresses { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<ExchangeSecurity> ExchangeSecurities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ExchangeSecurity>()
                .HasKey(t => new { t.ExchangeID, t.SecurityID });
            base.OnModelCreating(builder);
        }
    }
}
