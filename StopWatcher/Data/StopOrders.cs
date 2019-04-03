    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class StopOrder
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int ExchangeID { get; set; }
        public int SecurityID { get; set; }
        public int PositionID { get; set; }
        public string TradingPair { get; set; }
        public double Units { get; set; }
        public double StopPriceUSD { get; set; }
        public double StopPriceBTC { get; set; }
        public double StopPercent { get; set; }
        public bool IsStop { get; set; }
        public User User { get; set; }
        public Exchange Exchange { get; set; }
        public Security Security { get; set; }
        public Position Position { get; set; }
    }
}
