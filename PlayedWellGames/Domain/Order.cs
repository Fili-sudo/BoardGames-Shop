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
        public User? User { get; }
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
                price += item.Quantity * item.GetProductPrice(); 
            }
            Price = price;
            ShippingAddress = user.Address;
        }
        public Order(List<OrderItem> orderItems, States state, string shippingAddress)
        {
            double price = 0;
            OrderItems = orderItems;
            State = state;
            foreach (var item in orderItems)
            {
                price += item.Quantity * item.GetProductPrice();
            }
            Price = price;
            ShippingAddress = shippingAddress;
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
            Price = Price + orderItem.Quantity * orderItem.GetProductPrice();
        }
        public void RemoveOrderItem(OrderItem orderItem)
        {
            if (OrderItems.Contains(orderItem))
            {
                OrderItems.Remove(orderItem);
                Price = Price - orderItem.Quantity * orderItem.GetProductPrice();
            }
        }
        public void UpdateOrderItemQuantity(OrderItem orderItem, int quantity)
        {
            OrderItem toUpdate = OrderItems.FirstOrDefault(x => x == orderItem);
            if (toUpdate != null)
            {
                int prevQuantity = toUpdate.Quantity;
                toUpdate.Quantity = quantity;
                Price += (quantity - prevQuantity) * toUpdate.GetProductPrice();
            }
        }
        public override string ToString()
        {
            string result = $"Order id: {Id}, Price: {Price}\nOrder items:\n{{ \n";
            foreach (var item in OrderItems)
            {
                result += "  " + item.ToString() + "\n";
            }
            result += "}";
            return result;
        }


    }
}
