using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum States { Pending, Confirmed, Canceled, Arrived }
    public class Order
    {
        public readonly int id;
        public int Id 
        {
            get { return id; } 
        }
        public List<Product> Products{ get; set; }
        public States State { get; set; }
        public double Price { get; set; }
        public RegularUser? User{ get; set; }
        public string Address 
        {
            get
            {
                if (User!=null)
                {
                    return User.Address;
                }
                else
                {
                    return Address;
                }
            }
            set { Address = value; }
        }
        public string Phone
        {
            get
            {
                if (User != null)
                {
                    return User.Phone;
                }
                else
                {
                    return Phone;
                }
            }
            set { Phone = value; }
        }
        public string Mail
        {
            get
            {
                if (User != null)
                {
                    return User.Mail;
                }
                else
                {
                    return Mail;
                }
            }
            set { Mail = value; }
        }


    }
}
