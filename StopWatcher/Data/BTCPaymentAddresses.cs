using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class BTCPaymentAddresses
    {
        public BTCPaymentAddresses()
        {
            this._BTCPaymentAddresses = new HashSet<BTCPaymentAddresses>();
        }

        public int ID { get; set; }
        public int UserID { get; set; }
        public string BTCAddress { get; set; }
        public DateTime DateGenerated { get; set; }
        public Guid CartID { get; set; }
        public ICollection<BTCPaymentAddresses> _BTCPaymentAddresses { get; set; }
    }
}
