using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Core
{
    public enum States { InProcessing, Pending, Confirmed, Canceled, Arrived }
    public class Order : Entity
    {
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public States State { get; set; }
        public double Price { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
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
            OrderItems = orderItems;
            State = state;
            Price = GetTotalPrice(orderItems);
            ShippingAddress = shippingAddress;
        }

        public double GetTotalPrice(List<OrderItem> orderItems)
        {
            double price = 0;
            foreach (var item in orderItems)
            {
                price += item.Quantity * item.GetProductPrice();
            }
            return price;
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
            OrderItem toUpdate = OrderItems.FirstOrDefault(x => x.Equals(orderItem));
            if (toUpdate != null)
            {
                int prevQuantity = toUpdate.Quantity;
                toUpdate.Quantity = quantity;
                Price += (quantity - prevQuantity) * toUpdate.GetProductPrice();
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Order) return false;
            Order other = (Order)obj;
            return other.Id == Id;
        }
        public override int GetHashCode()
        {
            return Id;
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
