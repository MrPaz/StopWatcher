using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Models
{
    public class GetTickerResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public GetTickerResult Result { get; set; }
    }

    public class GetTickerResult
    {
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Last { get; set; }
    }
}
