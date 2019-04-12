    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class StopOrder
    {
        public int ID { get; set; }
        //public string UserID { get; set; }
        public int? PositionID { get; set; }
        //public int? OpenOrderID { get; set; }
        public string TradingPair { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal Units { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal? StopPriceUSD { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal StopPriceBTC { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal StopPercent { get; set; }
        //public User User { get; set; }
        public Position Position { get; set; }
        public OpenOrder OpenOrder { get; set; }
    }
}
