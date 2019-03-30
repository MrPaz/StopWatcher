using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class MockPositionData
    {

        public static Position[] positions =
        {
            new Position
            {
                //ID = 1000,
                UserID = "6d83469d-b2d8-46a4-acbc-3ab86b4f890f",
                ExchangeID = 1,
                SecurityID = 1,
                Units = 2.5,
                WtdAvgBuyPriceUSD = 3250.00,
                WtdAvgBuyPriceBTC = 1.0,
                IsStop = true,
            },
            new Position
            {
                //ID = 1001,
                UserID = "6d83469d-b2d8-46a4-acbc-3ab86b4f890f",
                ExchangeID = 1,
                SecurityID = 2,
                Units = 25,
                WtdAvgBuyPriceUSD = 140.00,
                WtdAvgBuyPriceBTC = 0.03000000,
                IsStop = true,
            },
            new Position
            {
                //ID = 1002,
                UserID = "6d83469d-b2d8-46a4-acbc-3ab86b4f890f",
                ExchangeID = 1,
                SecurityID = 3,
                Units = 100,
                WtdAvgBuyPriceUSD = 25.00,
                WtdAvgBuyPriceBTC = .00080000,
                IsStop = true,
            }
        };
        public static Exchange[] Exchanges = {
            new Exchange
            {
                UserID = "6d83469d-b2d8-46a4-acbc-3ab86b4f890f",
                Name = "Bittrex",
                ExchangeSecurities =
                {
                    new ExchangeSecurity{
                        Security = new Security
                        {
                            Name = "Bitcoin",
                            Ticker = "BTC",
                            TradingPair = "BTC/USD",
                            PxUSD = 4000.00,
                            PxBTC = 1.0,
                        }
                    },

                    new ExchangeSecurity{
                        Security = new Security
                        {
                            Name = "Ethereum",
                            Ticker = "ETH",
                            TradingPair = "ETH/USD",
                            PxUSD = 135.00,
                            PxBTC = .034,
                        }
                    },

                    new ExchangeSecurity{
                        Security = new Security
                        {
                            Name = "Litecoin",
                            Ticker = "LTC",
                            TradingPair = "LTC/USD",
                            PxUSD = 61,
                            PxBTC = .0145,
                        }
                    }
                }
            }
        };
    }
    public class MockSecurityData
    {
        public static Security[] security =
        {
            new Security
            {
                //ID = 1,
                Name = "Bitcoin",
                Ticker = "BTC",
                TradingPair = "BTC/USD",
                PxUSD = 4000.00,
                PxBTC = 1.0
            },

        new Security
            {
                //ID = 2,
                Name = "Ethereum",
                Ticker = "ETH",
                TradingPair = "ETH/USD",
                PxUSD = 138.00,
                PxBTC = .03500000
            },
            new Security
            {
                //ID = 3,
                Name = "Litecoin",
                Ticker = "LTC",
                TradingPair = "LTC/USD",
                PxUSD = 55.00,
                PxBTC = .01000000
            }
        };
    }
}
