using StopWatcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class MarketData
    {
        public MarketData()
        {

        }

        public int ID { get; set; }
        public GetMarketSummaryResult MarketSummarries { get; set; }
        //public string MarketName { get; set; }
        //public float High { get; set; }
        //public float Low { get; set; }
        //public float Volume { get; set; }
        //public float Last { get; set; }
        //public float BaseVolume { get; set; }
        //public DateTime TimeStamp { get; set; }
        //public float Bid { get; set; }
        //public float Ask { get; set; }
        //public int OpenBuyOrders { get; set; }
        //public int OpenSellOrders { get; set; }
        //public float PrevDay { get; set; }
        //public DateTime Created { get; set; }
    }
}
