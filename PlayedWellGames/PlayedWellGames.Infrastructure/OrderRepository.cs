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
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Order> AddOrder(Order order, CancellationToken cancellationToken)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> AddOrderItemToOrder(int orderId, int orderItemId, CancellationToken cancellationToken)
        {
            var orderItem = _context.OrderItems.Include(p => p.Product).FirstOrDefault(x => x.Id == orderItemId);
            var order = _context.Orders.Include(p => p.OrderItems).FirstOrDefault(x => x.Id == orderId);
            if(orderItem == null || order == null) { return null; }

            order.AddOrderItem(orderItem);

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
            return order;

        }

        public async Task<Order> RemoveOrderItemFromOrder(int orderId, int orderItemId, CancellationToken cancellationToken)
        {
            var orderItem = _context.OrderItems.Include(p => p.Product).FirstOrDefault(x => x.Id == orderItemId);
            var order = _context.Orders.Include(p => p.OrderItems).FirstOrDefault(x => x.Id == orderId);
            if (orderItem == null || order == null) { return null; }

            order.RemoveOrderItem(orderItem);
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;

        }

        public async Task<Order> UpdateOrderItemFromOrder(int orderId, int orderItemId, int newQuantity, CancellationToken cancellationToken)
        {
            var orderItem = _context.OrderItems.Include(p => p.Product).FirstOrDefault(x => x.Id == orderItemId);
            var order = _context.Orders.Include(p => p.OrderItems).FirstOrDefault(x => x.Id == orderId);
            if (orderItem == null || order == null) { return null; }

             order.UpdateOrderItemQuantity(orderItemId, newQuantity);
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;

        }

        public async Task DeleteOrder(int id, CancellationToken cancellationToken)
        {
            var orderToBeDeleted = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (orderToBeDeleted == null) { throw new Exception("Order not found exception"); }
            _context.Orders.Remove(orderToBeDeleted);
            await _context.SaveChangesAsync();
        }


        public async Task<Order> GetOrderById(int id, CancellationToken cancellationToken)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null) { throw new Exception("Order not found exception"); }
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken)
        {

            //var all = _context.Orders.Include(p => p.User).ToList();
            //return all;

            var all2 = _context.Orders
                .Include(p => p.OrderItems)
                    .ThenInclude(g => g.Product).ToList();
            return all2;

            //return _context.Orders.ToList();
        }

        public async Task UpdateOrder(int id, Order newOrder, CancellationToken cancellationToken)
        {
            var toUpdate = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (toUpdate == null) { throw new Exception("Order not found exception"); }
            toUpdate.State = newOrder.State;
            toUpdate.OrderItems = newOrder.OrderItems;
            toUpdate.Price = newOrder.Price;
            toUpdate.ShippingAddress = newOrder.ShippingAddress;

            _context.Orders.Update(toUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderState(int id, States newState, CancellationToken cancellationToken)
        {
            var toUpdate = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (toUpdate == null) { throw new Exception("Order not found exception"); }
            toUpdate.State = newState;

            _context.Orders.Update(toUpdate);
            await _context.SaveChangesAsync();
        }

       
    }
}
