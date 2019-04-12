using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using StopWatcher.Data;
using System;
using System.Threading.Tasks;

namespace PriceUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase("test");
            ApplicationDbContext context = new ApplicationDbContext(builder.Options);
            StopWatcher.Services.BittrexService bittrexService = new StopWatcher.Services.BittrexService(context);
            while (true)
            {
                
                StopWatcher.Models.GetMarketSummaryResult[]  result = bittrexService.GetMarketSummaries().Result;
               Console.WriteLine(result);
                System.Threading.Thread.Sleep(6000);



            }

            
        }
    }
}
