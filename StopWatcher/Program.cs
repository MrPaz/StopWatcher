using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StopWatcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webhost = CreateWebHostBuilder(args).Build();

            if (args.Contains("loadsampledata"))
            {
                IConfiguration configuration = (IConfiguration)webhost.Services.GetService(typeof(IConfiguration));
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                var optionsBuilder = new DbContextOptionsBuilder<Data.ApplicationDbContext>();
                optionsBuilder.UseSqlServer(connectionString);
                Data.ApplicationDbContext applicationDbContext = new Data.ApplicationDbContext(optionsBuilder.Options);

                ////If my database's categories table is empty, add mock data here:
                //if (!applicationDbContext.Positions.Any())
                //{
                //    applicationDbContext.Exchanges.AddRange(Data.MockExchangeData.exchanges);
                //    applicationDbContext.Positions.AddRange(Data.MockPositionData.positions);
                //    applicationDbContext.Securities.AddRange(Data.MockSecurityData.securities);

                //    applicationDbContext.SaveChanges();
                //}
            }
            else
            {
                webhost.Run();
            }
            webhost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
