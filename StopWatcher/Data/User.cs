using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class User : IdentityUser
    {
        public User() : base()
        {
            this.Positions = new HashSet<Position>();
            this.OpenOrders = new HashSet<OpenOrder>();
            this.Exchanges = new HashSet<Exchange>();
        }

        public User(string userName) : base(userName)
        {
            this.Positions = new HashSet<Position>();
            this.OpenOrders = new HashSet<OpenOrder>();
            this.Exchanges = new HashSet<Exchange>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AddressID { get; set; }
        public int? PlanID { get; set; }
        public int? CartID { get; set; }
        public DateTime? PlanStartDate { get; set; }
        public DateTime? PlanEndDate { get; set; }
        public Address Address { get; set; }
        public Plan Plan { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Position> Positions { get; set; }
        public ICollection<OpenOrder> OpenOrders { get; set; }
        public ICollection<Exchange> Exchanges { get; set; }
    }
}
