using PlayedWellGames.Application;
using PlayedWellGames.Core;
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
        public OrderItemRepository()
        {
            _orderItems = new List<OrderItem>();
        }

        public async Task AddOrderItem(OrderItem orderItem, CancellationToken cancellationToken)
        {
            _orderItems.Add(orderItem);
        }

        public Task DeleteOrderItem(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderItem> GetOrderItemById(int id, CancellationToken cancellationToken)
        {
            var orderItem = _orderItems.FirstOrDefault(x => x.Id == id);
            if (orderItem == null) { throw new Exception("Product not found exception"); }
            return orderItem;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(CancellationToken cancellationToken)
        {
            return _orderItems;
        }
    }
}
