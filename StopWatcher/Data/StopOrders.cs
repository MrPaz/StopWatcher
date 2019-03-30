using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class StopOrder
    {
        public int ID { get; set; }
        public int ExchangeID { get; set; }
        public int SecurityID { get; set; }
        public decimal Units { get; set; }
        public string TradingPair { get; set; }
        public decimal StopPriceUSD { get; set; }
        public decimal StopPriceBTC { get; set; }
        public decimal StopPercent { get; set; }
        public bool IsStop { get; set; }
        public User User { get; set; }
        public string UserID { get; set; }
        public Exchange Exchange { get; set; }
        public Security Security { get; set; }
    }
}
