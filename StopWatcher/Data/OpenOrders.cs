using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class OpenOrders
    {
        public OpenOrders()
        {
            this._OpenOrders = new HashSet<OpenOrders>();
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
        public ICollection<OpenOrders> _OpenOrders { get; set; }
    }
}
