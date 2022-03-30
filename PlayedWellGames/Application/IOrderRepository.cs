using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById (int id);
        void CreateOrder(Order order);
        void UpdateOrder(int orderId, OrderItem oldOrderItem, OrderItem newOrderItem);
        void DeleteProduct(int orderId, OrderItem orderItem);
    }
}
