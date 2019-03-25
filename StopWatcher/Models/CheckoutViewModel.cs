using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Models
{
    public class CheckoutViewModel
    {
        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string ShippingStreet1 { get; set; }

        public string ShippingStreet2 { get; set; }

        public string ShippingCity { get; set; }

        public string ShippingRegion { get; set; }

        public string ShippingLocale { get; set; }

        public string ShippingCountry { get; set; }

        public string ShippingPostalCode { get; set; }

    }
}
