using PlayedWellGames.Application;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }
        public async Task AddOrder(Order order, CancellationToken cancellationToken)
        {
            _orders.Add(order);
        }

        public async Task DeleteOrder(int id, CancellationToken cancellationToken)
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

        public async Task<Order> GetOrderById(int id, CancellationToken cancellationToken)
        {
            var order = _orders.FirstOrDefault(x => x.Id == id);
            if(order == null) { throw new Exception("Order not found exception"); }
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken)
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
