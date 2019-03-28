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
               // ID = 1000,
                UserID = 1,
                Ticker = "SPX",
                Name = "S&P 500",
                Exchange = "NYSE",
                Units = 100
            },
            new Position
            {
                //ID = 1001,
                UserID = 2,
                Ticker = "AAPL",
                Name = "Apple",
                Exchange = "NASDAQ",
                Units = 500
            },
            new Position
            {
                //ID = 1002,
                UserID = 3,
                Ticker = "PHYS",
                Name = "Sprott Physical Gold Fund",
                Exchange = "TSX",
                Units = 300
            }
        };
    }
}
