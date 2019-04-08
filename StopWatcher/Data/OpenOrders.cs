using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class OpenOrder
    {
        public OpenOrder()
        {
        }
        public int ID { get; set; }
        public string UserID { get; set; }
        public int ExchangeID { get; set; }
        public int SecurityID { get; set; }
        public int? StopOrderID { get; set; }
        public double Units { get; set; }
        public double BidPxUSD { get; set; }
        public double BidPxBTC { get; set; }
        public bool IsStop { get; set; }
        public User User { get; set; }
        public Exchange Exchange { get; set; }
        public Security Security { get; set; }
        public StopOrder StopOrder { get; set; }
    }
}
