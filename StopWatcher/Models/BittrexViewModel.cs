using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Models
{
    public class GetTicker
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

    public class GetMarketSummary
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public GetMarketSummaryResult Result { get; set; }
    }
    
    public class GetMarketSummaryResult
    {
        public int ID { get; set; }
        public string MarketName { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Volume { get; set; }
        public float Last { get; set; }
        public float BaseVolume { get; set; }
        public DateTime TimeStamp { get; set; }
        public float Bid { get; set; }
        public float Ask { get; set; }
        public int OpenBuyOrders { get; set; }
        public int OpenSellOrders { get; set; }
        public float PrevDay { get; set; }
        public DateTime Created { get; set; }
    }

    public class GetBalances
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public GetBalancesResult Result { get; set; }
    }

    public class GetBalancesResult
    {
        public string Currency { get; set; }
        public float Balance { get; set; }
        public float Available { get; set; }
        public float Pending { get; set; }
        public string CryptoAddress { get; set; }
        public bool Requested { get; set; }
        public string Uuid { get; set; }
    }

    public class GetOpenOrders
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public GetOpenOrdersResult Result { get; set; }
    }

    public class GetOpenOrdersResult
    {
        public string Uuid { get; set; }
        public string OrderUuid { get; set; }
        public string Exchange { get; set; }
        public string OrderType { get; set; }
        public float Quantity { get; set; }
        public float QuantityRemaining { get; set; }
        public float Limit { get; set; }
        public float CommissionPaid { get; set; }
        public float Price { get; set; }
        public float PricePerUnit { get; set; }
        public DateTime Opened { get; set; }
        public DateTime Closed { get; set; }
        public bool CancelInitiated { get; set; }
        public bool ImmediateOrCancel { get; set; }
        public bool IsConditional { get; set; }
    }
}
