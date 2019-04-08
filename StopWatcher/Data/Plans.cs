using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int Months { get; set; }
    }
}
