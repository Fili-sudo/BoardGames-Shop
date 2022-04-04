using PlayedWellGames.Application;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Infrastructure
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
            var orderToBeDeleted = _orders.FirstOrDefault(x => x.Id == id);
            if (orderToBeDeleted == null) { throw new Exception("Order not found exception"); }
            _orders.Remove(orderToBeDeleted);
        }

        public void DeleteOrderItem(int orderId, OrderItem orderItem)
        {
            var order = _orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null) { throw new Exception("Order not found exception"); }

            var orderItemToBeDeleted = order.OrderItems.FirstOrDefault(x => x.Equals(orderItem));
            if (orderItemToBeDeleted == null) { throw new Exception("OrderItem not found exception"); }

            order.RemoveOrderItem(orderItemToBeDeleted);
        }

        public Order GetOrderById(int id)
        {
            var order = _orders.FirstOrDefault(x => x.Id == id);
            if(order == null) { throw new Exception("Order not found exception"); }
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }

        public void UpdateOrder(int orderId, OrderItem oldOrderItem, OrderItem newOrderItem)
        {
           var OrdertoBeUpdated = _orders.FirstOrDefault(x => x.Id == orderId);
            if (OrdertoBeUpdated == null) { throw new Exception("Order not found exception"); }
     
            OrdertoBeUpdated.UpdateOrderItemQuantity(oldOrderItem, newOrderItem.Quantity);
        }
    }
}
