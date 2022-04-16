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
    public class OrderItemRepository : IOrderItemRepository
    {
        private List<OrderItem> _orderItems;

        private AppDbContext _context;
        public OrderItemRepository()
        {
            _orderItems = new List<OrderItem>();
        }
        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> AddOrderItem(OrderItem orderItem, CancellationToken cancellationToken)
        {
            //_orderItems.Add(orderItem);
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();

            return orderItem;
        }

        public async Task<OrderItem?> DeleteOrderItem(int id, CancellationToken cancellationToken)
        {
            //var orderItemToBeDeleted = _orderItems.FirstOrDefault(x => x.Id == id);
            //if (orderItemToBeDeleted == null) { throw new Exception("Order Item not found exception"); }
            //_orderItems.Remove(orderItemToBeDeleted);

            var orderItemToBeDeleted = _context.OrderItems.FirstOrDefault(x => x.Id == id);
            if (orderItemToBeDeleted == null) { return null; }
            _context.OrderItems.Remove(orderItemToBeDeleted);
            await _context.SaveChangesAsync();

            return orderItemToBeDeleted;
        }

        public async Task<OrderItem?> GetOrderItemById(int id, CancellationToken cancellationToken)
        {
            //var orderItem = _orderItems.FirstOrDefault(x => x.Id == id);
            //if (orderItem == null) { throw new Exception("Order Item not found exception"); }
            //return orderItem;

            var orderItem = _context.OrderItems.FirstOrDefault(x => x.Id == id);
            if (orderItem == null) { return null; }
            return orderItem;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(CancellationToken cancellationToken)
        {
            //return _orderItems;

            return _context.OrderItems.ToList();
        }

        public async Task<OrderItem?> UpdateOrderItemQuantity(int id, int newQuantity, CancellationToken cancellationToken)
        {
            var toUpdate = _context.OrderItems.FirstOrDefault(x => x.Id == id);
            if (toUpdate == null) { return null; }
            toUpdate.Quantity = newQuantity;

            _context.OrderItems.Update(toUpdate);
            await _context.SaveChangesAsync();
            return toUpdate;
        }
    }
}
