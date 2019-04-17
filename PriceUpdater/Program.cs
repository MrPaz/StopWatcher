using Microsoft.EntityFrameworkCore;
using StopWatcher.Data;
using System;
using Microsoft.Extensions.Configuration;

namespace PriceUpdater
{
    class Program
    {
        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        static void Main(string[] args)
        {
            
            DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase("test"); //need to switch back to UseSqlServer after testing
            //builder.UseSqlServer(System.Configuration.GetConnectionString("DefaultConnection"));
            
            ApplicationDbContext context = new ApplicationDbContext(builder.Options);
            StopWatcher.Services.BittrexService bittrexService = new StopWatcher.Services.BittrexService(context);
            while (true)
            {
                StopWatcher.Models.GetMarketSummaryResult[]  result = bittrexService.GetMarketSummaries().Result;
                Console.WriteLine(result);
                System.Threading.Thread.Sleep(10000);
            }                        
        }
    }
}
