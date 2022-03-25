using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RegularUser : User
    {

        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ShoppingCart? MyCart { get; set; }

        public RegularUser(int UserId, string userName, string Pass, 
                           string FirstName, string LastName, string Address,
                           string Mail, string Phone) : base(UserId, userName, Pass)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.Mail = Mail;
            this.Phone = Phone;
        }
    }
}
