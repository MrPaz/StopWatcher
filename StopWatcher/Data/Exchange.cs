using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class Exchange
    {
        public Exchange()
        {
            //this.ExchangeSecurities = new HashSet<ExchangeSecurity>();
        }
        public int ID { get; set; }
        public int MarketDataId { get; set; }
        public string Name { get; set; }
        public string APIKey { get; set; }
        MarketData MarketData { get; set; }
        //public ICollection<ExchangeSecurity> ExchangeSecurities { get; set; }
    }
}
