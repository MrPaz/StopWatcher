using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public decimal Units { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal WtdAvgBuyPriceUSD { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal WtdAvgBuyPriceBTC { get; set; }
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