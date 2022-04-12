using PlayedWellGames.Application;
using PlayedWellGames.Core;
using PlayedWellGames.Infrastructure.Data;
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

        private AppDbContext _context;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddOrder(Order order, CancellationToken cancellationToken)
        {
            //_orders.Add(order);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id, CancellationToken cancellationToken)
        {
            var orderToBeDeleted = _orders.FirstOrDefault(x => x.Id == id);
            if (orderToBeDeleted == null) { throw new Exception("Order not found exception"); }
            _orders.Remove(orderToBeDeleted);

            //var orderToBeDeleted = _context.Orders.FirstOrDefault(x => x.Id == id);
            //if (orderToBeDeleted == null) { throw new Exception("Order not found exception"); }
            //_context.Orders.Remove(orderToBeDeleted);
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
            //var order = _orders.FirstOrDefault(x => x.Id == id);
            //if(order == null) { throw new Exception("Order not found exception"); }
            //return order;

            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null) { throw new Exception("Order not found exception"); }
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken)
        {
            //return _orders;

            return _context.Orders.ToList();
        }

        public void UpdateOrder(int orderId, OrderItem oldOrderItem, OrderItem newOrderItem)
        {
           var OrdertoBeUpdated = _orders.FirstOrDefault(x => x.Id == orderId);
            if (OrdertoBeUpdated == null) { throw new Exception("Order not found exception"); }
     
            OrdertoBeUpdated.UpdateOrderItemQuantity(oldOrderItem, newOrderItem.Quantity);
        }
    }
}
