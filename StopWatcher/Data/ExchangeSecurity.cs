using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class ExchangeSecurity
    {
        public int ExchangeID { get; set; }
        public Exchange Exchange { get; set; }

        public int SecurityID { get; set; }
        public Security Security { get; set; }
    }
}
