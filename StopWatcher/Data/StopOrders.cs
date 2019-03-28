using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class StopOrders
    {
        public StopOrders()
        {
            this._StopOrders = new HashSet<StopOrders>();
        }
        public int ID { get; internal set; }
        public int UserID { get; set; }
        public string Exchange { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public decimal Units { get; set; }
        public decimal BidPxUSD { get; set; }
        public decimal BidPxBTC { get; set; }
        public bool IsStop { get; set; }
        public ICollection<StopOrders> _StopOrders { get; set; }
    }
}
