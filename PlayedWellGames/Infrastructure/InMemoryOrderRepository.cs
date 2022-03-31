using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private List<Order> _orders;

        public InMemoryOrderRepository()
        {
            _orders = new List<Order>();
        }
        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public void DeleteOrder(int id)
        {
            Order orderToBeDeleted = _orders.FirstOrDefault(x => x.Id == id);
            if (orderToBeDeleted == null) { throw new Exception("Order not found exception"); }
            _orders.Remove(orderToBeDeleted);
        }

        public void DeleteOrderItem(int orderId, OrderItem orderItem)
        {
            Order order = _orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null) { throw new Exception("Order not found exception"); }

            OrderItem orderItemToBeDeleted = order.OrderItems.FirstOrDefault(x => x.Equals(orderItem));
            if (orderItemToBeDeleted == null) { throw new Exception("OrderItem not found exception"); }

            order.RemoveOrderItem(orderItemToBeDeleted);
        }

        public Order GetOrderById(int id)
        {
            foreach (Order order in _orders)
            {
                if (order.Id == id) { return order; }
            }
            throw new Exception("Order not found exception");
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }

        public void UpdateOrder(int orderId, OrderItem oldOrderItem, OrderItem newOrderItem)
        {
           Order OrdertoBeUpdated = _orders.FirstOrDefault(x => x.Id == orderId);
            if (OrdertoBeUpdated == null) { throw new Exception("Order not found exception"); }
     
            OrdertoBeUpdated.UpdateOrderItemQuantity(oldOrderItem, newOrderItem.Quantity);
        }
    }
}
