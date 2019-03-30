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

        public Guid ID { get; set; }
        public int UserID { get; set; }
        public int PlansID { get; set; }
        public ICollection<Cart> _Cart { get; set; }
    }
}
