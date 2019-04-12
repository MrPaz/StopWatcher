using Bittrex.Net.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StopWatcher.Data;
using StopWatcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Services
{
    public class BittrexService
    {
        private ApplicationDbContext _context;

        public BittrexService(ApplicationDbContext context)
        {
            _context = context;
        }

        readonly string marketName = "Bittrex";

        public async Task<GetCurrenciesResult[]> GetCurrencies()
        {
            Bittrex.Net.BittrexClient bittrexClient = new Bittrex.Net.BittrexClient();

            var allCurrencies = (await bittrexClient.GetCurrenciesAsync())
                .Data.Select(x => new GetCurrenciesResult
            {
                Currency = x.Currency,
                CurrencyLong = x.CurrencyLong,
                MinConfirmation = x.MinConfirmation,
                TxFee = x.TransactionFee,
                IsActive = x.IsActive,
                CoinType = x.CoinType,
                BaseAddress = x.BaseAddress
            }).ToArray();


            foreach (var currency in allCurrencies)
            {
                var positionData = _context.Positions.Include(x => x.Security)
                    .FirstOrDefault(x => x.Security.Ticker == currency.Currency);
                if(positionData != null)
                {
                    positionData.Security.Name = currency.CurrencyLong;
                }
            }
            await _context.SaveChangesAsync();

            return allCurrencies;
        }

        public async Task<GetMarketSummaryResult[]> GetMarketSummaries()
        {
            Bittrex.Net.BittrexClient bittrexClient = new Bittrex.Net.BittrexClient();
            var allSummaries = (await bittrexClient.GetMarketSummariesAsync())
                .Data.Select(x => new GetMarketSummaryResult
            {
                MarketName = x.MarketName,
                High = (x.High ?? 0),
                Low = (x.Low ?? 0),
                Volume = (x.Volume ?? 0),
                Last = (x.Last ?? 0),
                BaseVolume = (x.BaseVolume ?? 0),
                TimeStamp = x.TimeStamp,
                Bid = (x.Bid ?? 0),
                Ask = (x.Ask ?? 0),
                OpenBuyOrders = (x.OpenBuyOrders ?? 0),
                OpenSellOrders = (x.OpenSellOrders ?? 0),
                PrevDay = (x.PrevDay ?? 0),
                Created = x.Created
            }).ToArray();

            //string testSuffix = "/public/getmarketsummaries";
            //string endpoint = "https://api.bittrex.com/api/v1.1" + testSuffix /*_myApiKey*/;
            ////https://api.bittrex.com/api/v1.1/account/getbalances?apikey=API_KEY
            ////https://api.bittrex.com/api/v1.1/market/getopenorders?apikey=API_KEY&market=BTC-LTC
            //System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            //string response = await httpClient.GetStringAsync(endpoint);
            ////GetMarketSummary typedReponse = Newtonsoft.Json.JsonConvert
            ////.DeserializeObject<GetMarketSummary>(response);
            //var typedReponse = Newtonsoft.Json.JsonConvert
            //    .DeserializeObject<Newtonsoft.Json.Linq.JObject>(response);
            //var marketSummaries = typedReponse.GetValue("result").ToArray();
            ////if(marketSummaries.)
            //var markets = marketSummaries.Select(market => new GetMarketSummaryResult
            //{
            //    MarketName = market["MarketName"].ToString(),
            //    High = decimal.Parse(market["High"].ToString()),
            //    Low = decimal.Parse(market["Low"].ToString()),
            //    Volume = decimal.Parse(market["Volume"].ToString()),
            //    Last = decimal.Parse(market["Last"].ToString()),
            //    BaseVolume = decimal.Parse(market["BaseVolume"].ToString()),
            //    TimeStamp = DateTime.Parse(market["TimeStamp"].ToString()),
            //    Bid = decimal.Parse(market["Bid"].ToString()),
            //    Ask = decimal.Parse(market["Ask"].ToString()),
            //    OpenBuyOrders = int.Parse(market["OpenBuyOrders"].ToString()),
            //    OpenSellOrders = int.Parse(market["OpenSellOrders"].ToString()),
            //    PrevDay = decimal.Parse(market["PrevDay"].ToString()),
            //    Created = DateTime.Parse(market["Created"].ToString())
            //}).ToArray();
            ////now need to get this data into db !!!
            foreach (var market in allSummaries)
            {
                var marketData = _context.MarketDatas.Include(x => x.MarketSummarries)
                    .FirstOrDefault(x => x.MarketSummarries.MarketName == market.MarketName);
                if (marketData == null)
                {
                    marketData = new MarketData
                    {
                        ExchangeID = _context.Exchanges.FirstOrDefault(x => x.Name == marketName).ID
                    };
                    _context.MarketDatas.Add(marketData);
                }
                if (marketData.MarketSummarries != null)
                {
                    _context.GetMarketSummaryResults.Remove(marketData.MarketSummarries);
                }
                marketData.MarketSummarries = market;

                var ticker = market.MarketName.Split('-')[1];

                var position = _context.Positions.Include(x => x.Security)
                    .FirstOrDefault(x => x.Security.Ticker == ticker);

                if (position != null)
                {
                    if (market.MarketName == "BTC-" + position.Security.Ticker)
                    {
                        position.Security.PxBTC = market.Last;
                    }
                    if (market.MarketName == "USD-" + position.Security.Ticker)
                    {
                        position.Security.PxUSD = market.Last;
                    }
                }
            }
            await _context.SaveChangesAsync();

            return allSummaries;
        }

        public async Task<GetBalancesResult[]> GetBalances(string userName, string key, string secret)
        {
            var user = _context.Users.Include(x => x.Exchanges)
                .FirstOrDefault(x => x.UserName == userName);
            var userExchange = user.Exchanges.FirstOrDefault(x => x.Name == "Bittrex");

            Bittrex.Net.BittrexClient bittrexClient = new Bittrex.Net.BittrexClient(
                new Bittrex.Net.Objects.BittrexClientOptions
                {
                    ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials(
                        //userExchange.APIKey.Split(",").First(), 
                        //userExchange.APIKey.Split(",").Last())
                        key, secret
                        )
                });

            var callResult = await bittrexClient.GetBalancesAsync();

            var balances  = callResult.Data.Select(x => new GetBalancesResult
            {
                Currency = x.Currency,
                Balance = (x.Balance ?? 0),
                Available = (x.Available ?? 0),
                Pending = (x.Pending ?? 0),
                CryptoAddress = x.CryptoAddress
            }).ToArray();

            foreach (var balance in balances)
            {
                var userPosition = _context.Positions
                    .FirstOrDefault(x => x.Security.Ticker == balance.Currency);

                if (userPosition == null)
                {

                    userPosition = new Position
                    {
                        UserID = user.Id,
                        ExchangeID = userExchange.ID,
                        Security = new Security
                        {
                             Ticker = balance.Currency
                        },
                        Units = balance.Balance
                    };
                    _context.Users.Single(x => x.UserName == userName)
                        .Positions.Add(userPosition);
                }
                else
                {
                    userPosition.Units = balance.Balance;
                }
            }
            await _context.SaveChangesAsync();

            return balances;
        }

        public async Task<GetOpenOrdersResult[]> GetOpenOrders(string userName, string key, string secret)
        {

            Bittrex.Net.BittrexClient bittrexClient = new Bittrex.Net.BittrexClient(
                new Bittrex.Net.Objects.BittrexClientOptions
                {
                    ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials(
                        //userExchange.APIKey.Split(",").First(), 
                        //userExchange.APIKey.Split(",").Last())
                        key, secret
                        )
                });

            var callResult = await bittrexClient.GetOpenOrdersAsync();

            var allOpenOrders = callResult.Data.Select(x => new GetOpenOrdersResult
                {
                    Uuid = x.Uuid,
                    OrderUuid = x.OrderUuid,
                    Exchange = x.Exchange,
                    OrderType = x.OrderType,
                    Quantity = x.Quantity,
                    QuantityRemaining = x.QuantityRemaining,
                    Limit = x.Limit,
                    CommissionPaid = x.CommissionPaid,
                    Price = x.Price,
                    PricePerUnit = x.PricePerUnit,
                    Opened = x.Opened,
                    Closed = x.Closed,
                    CancelInitiated = x.CancelInitiated,
                    ImmediateOrCancel =x.ImmediateOrCancel,
                    IsConditional = x.IsConditional
                }).ToArray();

            foreach (var order in allOpenOrders)
            {
                var ticker = order.Exchange.Split('-')[1];
                var user = _context.Users.Include(x => x.Exchanges).FirstOrDefault(x => x.UserName == userName);
                var userExchange = user.Exchanges.FirstOrDefault(x => x.Name == "Bittrex");
                var orderData = _context.OpenOrders.Include(x => x.Security)
                    .FirstOrDefault(x => x.OrderUuid == order.OrderUuid);
                var security = _context.Securities.FirstOrDefault(x => x.Ticker == ticker);

                if (orderData == null)
                {
                    if (security == null)
                    {
                        security = new Security
                        {
                            Ticker = ticker
                        };
                    }

                    orderData = new OpenOrder
                    {
                        UserID = user.Id,
                        ExchangeID = userExchange.ID,
                        OrderUuid = order.OrderUuid,
                        Security = security,
                        Quantity = order.Quantity,
                        QuantityRemaining = order.QuantityRemaining,
                        OrderType = order.OrderType,
                        TradingPair = order.Exchange,
                        OrderPx = order.PricePerUnit

                    };
                    _context.Users.Single(x => x.UserName == userName)
                        .OpenOrders.Add(orderData);
                }
                else
                {
                    orderData.Quantity = order.Quantity;
                    orderData.QuantityRemaining = order.QuantityRemaining;
                    orderData.OrderPx = order.PricePerUnit;
                }
            }
            await _context.SaveChangesAsync();

            return allOpenOrders;
        }
    }
}
