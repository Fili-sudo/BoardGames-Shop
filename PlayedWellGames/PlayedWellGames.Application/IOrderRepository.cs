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
        Task UpdateOrder(int id, Order newOrder, CancellationToken cancellationToken);
        Task DeleteOrder(int id, CancellationToken cancellationToken);
        Task UpdateOrderState(int id, States newState, CancellationToken cancellationToken);
    }
}
