using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application
{
    public interface IOrderRepository
    {
        Task <IEnumerable<Order>> GetOrders(CancellationToken cancellationToken);
        Task<Order> GetOrderById (int id, CancellationToken cancellationToken);
        Task AddOrder(Order order, CancellationToken cancellationToken);
        void UpdateOrder(int orderId, OrderItem oldOrderItem, OrderItem newOrderItem);
        void DeleteOrderItem(int orderId, OrderItem orderItem);

        void DeleteOrder(int id);
    }
}
