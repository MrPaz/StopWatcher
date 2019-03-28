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
            this.Positions = new HashSet<Position>();
        }
        public int ID { get; internal set; }
        public int UserID { get; set; }
        public string Exchange { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public decimal Units { get; set; }
        public decimal WtdAvgBuyPriceUSD { get; set; }
        public decimal WtdAvgBuyPriceBTC { get; set; }
        public bool IsStop { get; set; }
        public ICollection<Position> Positions { get; set; }
    }
}