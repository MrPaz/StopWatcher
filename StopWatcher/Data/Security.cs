using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class Security
    {
        public Security()
        {
            this.ExchangeSecurities = new HashSet<ExchangeSecurity>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal? PxUSD { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal PxBTC { get; set; }
        public ICollection<ExchangeSecurity> ExchangeSecurities { get; set; }

    }
}
