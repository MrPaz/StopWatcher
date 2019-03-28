using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class Plans
    {
        public Plans()
        {
            this._Plans = new HashSet<Plans>();
        }

        public int ID { get; set; }
        public decimal Price { get; set; }
        public int Months { get; set; }
        public ICollection<Plans> _Plans { get; set; }
    }
}
