using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class Plan
    {
        public Plan()
        {
        }

        public int ID { get; set; }
        public decimal Price { get; set; }
        public int Months { get; set; }
    }
}
