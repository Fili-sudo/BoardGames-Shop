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
        IEnumerable<Order> GetOrders();
        Order GetOrderById (int id);
        void AddOrder(Order order);
        void UpdateOrder(int orderId, OrderItem oldOrderItem, OrderItem newOrderItem);
        void DeleteOrderItem(int orderId, OrderItem orderItem);

        void DeleteOrder(int id);
    }
}
