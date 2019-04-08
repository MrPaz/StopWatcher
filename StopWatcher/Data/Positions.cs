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
            this.StopOrders = new HashSet<StopOrder>();
        }
        public int ID { get; internal set; }
        public string UserID { get; set; }
        public int ExchangeID { get; set; }
        public int SecurityID { get; set; }
        public double Units { get; set; }
        public double WtdAvgBuyPriceUSD { get; set; }
        public double WtdAvgBuyPriceBTC { get; set; }
        public bool IsStop { get; set; }
        public User User { get; set; }
        public Exchange Exchange { get; set; }
        public Security Security { get; set; }
        //StopOrder StopOrder { get; set; }
        public ICollection<StopOrder> StopOrders { get; set; }
        //Position may have several StopOrders...a collection of Stop Orders, 
        //seems like it should contain the StopOrderIDs

    }
}