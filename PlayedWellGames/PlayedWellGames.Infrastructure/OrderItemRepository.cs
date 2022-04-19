using Microsoft.EntityFrameworkCore;
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
        private AppDbContext _context;
        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> AddOrderItem(OrderItem orderItem, CancellationToken cancellationToken)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == orderItem.ProductId);
            var order = _context.Orders.Include(p => p.OrderItems).FirstOrDefault(x => x.Id == orderItem.OrderId);
            if (product == null) { return null; }
            orderItem.Product = product;

            if (orderItem.OrderId != null)
            {
                if(order == null) { return null; }
                orderItem.Order = order;
                order.AddOrderItem(orderItem);

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
            }
                else
                {
                    await _context.OrderItems.AddAsync(orderItem);
                    await _context.SaveChangesAsync();
                }
            

            return orderItem;
        }

        public async Task<OrderItem?> DeleteOrderItem(int id, CancellationToken cancellationToken)
        {

            var orderItemToBeDeleted = _context.OrderItems.FirstOrDefault(x => x.Id == id);
            if (orderItemToBeDeleted == null || orderItemToBeDeleted.OrderId != null) { return null; }
            _context.OrderItems.Remove(orderItemToBeDeleted);
            await _context.SaveChangesAsync();

            return orderItemToBeDeleted;
        }

        public async Task<OrderItem?> GetOrderItemById(int id, CancellationToken cancellationToken)
        {
            var orderItem = _context.OrderItems.FirstOrDefault(x => x.Id == id);
            if (orderItem == null) { return null; }
            return orderItem;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(CancellationToken cancellationToken)
        {
            return _context.OrderItems.ToList();
        }

        public async Task<OrderItem?> UpdateOrderItemQuantity(int id, int newQuantity, CancellationToken cancellationToken)
        {
            var toUpdate = _context.OrderItems.FirstOrDefault(x => x.Id == id);
            if (toUpdate == null || toUpdate.OrderId != null) { return null; }
            toUpdate.Quantity = newQuantity;

            _context.OrderItems.Update(toUpdate);
            await _context.SaveChangesAsync();
            return toUpdate;
        }
    }
}
