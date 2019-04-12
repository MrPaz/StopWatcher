using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid? OrderUuid { get; set; }
        public string TradingPair { get; set; }
        public Bittrex.Net.Objects.OrderSideExtended OrderType { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal QuantityRemaining { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal? OrderPx { get; set; }
        //[Column(TypeName = "decimal(20, 8)")]
        //public decimal? BidPxBTC { get; set; }
        public bool IsStop { get; set; }
        public User User { get; set; }
        public Exchange Exchange { get; set; }
        public Security Security { get; set; }
        public StopOrder StopOrder { get; set; }
    }
}
