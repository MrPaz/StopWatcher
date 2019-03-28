using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class Exchange
    {
        public Exchange()
        {
            this._Exchange = new HashSet<Exchange>();
        }
        public int ID { get; internal set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string APIKey { get; set; }
        public ICollection<Exchange> _Exchange { get; set; }
    }
}
