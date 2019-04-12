using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "decimal(20, 8)")]
        public decimal High { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal Low { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal Volume { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal Last { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal BaseVolume { get; set; }
        public DateTime TimeStamp { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal Bid { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal Ask { get; set; }
        public int OpenBuyOrders { get; set; }
        public int OpenSellOrders { get; set; }
        [Column(TypeName = "decimal(20, 8)")]
        public decimal PrevDay { get; set; }
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
        public decimal Balance { get; set; }
        public decimal Available { get; set; }
        public decimal Pending { get; set; }
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
        public Guid? Uuid { get; set; }
        public Guid? OrderUuid { get; set; }
        public string Exchange { get; set; }
        public Bittrex.Net.Objects.OrderSideExtended OrderType { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityRemaining { get; set; }
        public decimal Limit { get; set; }
        public decimal CommissionPaid { get; set; }
        public decimal Price { get; set; }
        public decimal? PricePerUnit { get; set; }
        public DateTime Opened { get; set; }
        public DateTime? Closed { get; set; }
        public bool CancelInitiated { get; set; }
        public bool ImmediateOrCancel { get; set; }
        public bool IsConditional { get; set; }
    }

    public class GetCurrencies
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public GetCurrenciesResult Result { get; set; }
    }

    public class GetCurrenciesResult
    {
        public string Currency { get; set; }
        public string CurrencyLong { get; set; }
        public int MinConfirmation { get; set; }
        public decimal TxFee { get; set; }
        public bool IsActive { get; set; }
        public string CoinType { get; set; }
        public string BaseAddress { get; set; }
    }
}
