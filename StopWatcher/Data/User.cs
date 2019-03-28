using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopWatcher.Data
{
    public class User
    {
        public User()
        {
            this._User = new HashSet<User>();
        }
        public int ID { get; internal set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AddressID { get; set; }
        public int CreditCardID { get; set; }
        public int PlanID { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public ICollection<User> _User { get; set; }
    }
}
