using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Order>
    {
        private IOrderRepository _orderRepository;
        public AddOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                OrderItems = new List<OrderItem>(),
                State = States.InProcessing,
                Price = 0,
                ShippingAddress = command.ShippingAddress,
                User = command.User,
                UserId = command.UserId,
            };
            var createdOrder = await _orderRepository.AddOrder(order, cancellationToken);

            return await Task.FromResult(createdOrder);
        }
    }
}
