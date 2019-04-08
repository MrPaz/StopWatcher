using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class Cart
    {
        public Cart()
        {
            this._Cart = new HashSet<Cart>();
        }

        public int ID { get; set; }
        public int PlansID { get; set; }
        public int BTCPaymentAddressID { get; set; }
        public Plan Plan { get; set; }
        public ICollection<Cart> _Cart { get; set; }
    }
}
