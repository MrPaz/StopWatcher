using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class BTCPaymentAddress
    {
        public BTCPaymentAddress()
        {
            this._BTCPaymentAddresses = new HashSet<BTCPaymentAddress>();
        }

        public int ID { get; set; }
        public string BTCAddress { get; set; }
        public DateTime DateGenerated { get; set; }
        public ICollection<BTCPaymentAddress> _BTCPaymentAddresses { get; set; }
    }
}
