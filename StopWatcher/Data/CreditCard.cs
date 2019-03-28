using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class CreditCard
    {
        public CreditCard()
        {
            this._CreditCard = new HashSet<CreditCard>();
        }

        public int ID { get; set; }
        public int UserID { get; set; }
        public int AddressID { get; set; }
        public string CardIssuer { get; set; }
        public int CardNumber { get; set; }
        public int CVC { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public ICollection<CreditCard> _CreditCard { get; set; }
    }
}
