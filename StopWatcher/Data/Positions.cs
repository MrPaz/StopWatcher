using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class Position
    {
        public Position()
        {
            
        }
        public int ID { get; internal set; }
        public string UserID { get; set; }
        public int ExchangeID { get; set; }
        public int SecurityID { get; set; }
        public double Units { get; set; }
        public double WtdAvgBuyPriceUSD { get; set; }
        public double WtdAvgBuyPriceBTC { get; set; }
        public bool IsStop { get; set; }
        public Exchange Exchange { get; set; }
        public Security Security { get; set; }
        public User User { get; set; }
    }
}