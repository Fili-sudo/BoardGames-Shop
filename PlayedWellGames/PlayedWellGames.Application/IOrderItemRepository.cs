using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace PlayedWellGames.Application
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItems(CancellationToken cancellationToken);
        Task<OrderItem> GetOrderItemById(int id, CancellationToken cancellationToken);
        Task AddOrderItem(OrderItem orderItem, CancellationToken cancellationToken);
        Task DeleteOrderItem(int id, CancellationToken cancellationToken);
        Task UpdateOrderItemQuantity(int id, int newQuantity, CancellationToken cancellationToken);
    }
}
