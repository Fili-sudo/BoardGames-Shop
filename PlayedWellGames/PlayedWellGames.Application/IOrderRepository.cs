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
        Task<IEnumerable<Order>> GetOrdersFromUser(string userId, CancellationToken cancellationToken);
        Task<Order> GetOrderById (int id, CancellationToken cancellationToken);
        Task<Order> AddOrder(Order order, CancellationToken cancellationToken);
        Task<Order> AddOrderItemToOrder(int orderId, int orderItemId, CancellationToken cancellationToken);
        Task<Order> RemoveOrderItemFromOrder(int orderId, int orderItemId, CancellationToken cancellationToken);
        Task<Order> UpdateOrderItemFromOrder(int orderId, int orderItemId, int newQuantity, CancellationToken cancellationToken);
        Task<Order> UpdateOrder(int id, Order newOrder, CancellationToken cancellationToken);
        Task<Order> DeleteOrder(int id, CancellationToken cancellationToken);
        Task UpdateOrderState(int id, States newState, CancellationToken cancellationToken);
    }
}
