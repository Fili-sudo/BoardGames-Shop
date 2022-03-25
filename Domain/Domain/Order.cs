using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum States { Pending, Confirmed, Canceled, Arrived }
    public class Order : Entity
    {
        public List<OrderItem> OrderItems { get; set; }
        public States State { get; set; }
        public double Price { get; set; }
        public User User { get; }
        public string ShippingAddress { get; set; }

        public Order() { }
        public Order(List<OrderItem> orderItems, States state, User user)
        {
            double price = 0;
            OrderItems = orderItems;
            State = state;
            User = user;
            foreach (var item in orderItems)
            {
                price += item.GetProductPrice(); 
            }
            Price = price;
            ShippingAddress = user.Address;
        }


    }
}
