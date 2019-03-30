using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class Security
    {
        public Security()
        {
            this.ExchangeSecurities = new HashSet<ExchangeSecurity>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string TradingPair { get; set; }
        public double PxUSD { get; set; }
        public double PxBTC { get; set; }
        public ICollection<ExchangeSecurity> ExchangeSecurities { get; set; }

    }
}
