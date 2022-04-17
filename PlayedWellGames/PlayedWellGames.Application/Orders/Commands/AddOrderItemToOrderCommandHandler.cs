using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class AddOrderItemToOrderCommandHandler : IRequestHandler<AddOrderItemToOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderItemToOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(AddOrderItemToOrderCommand command, CancellationToken cancellationToken)
        {
            var updatedOrder = await _orderRepository.AddOrderItemToOrder(command.OrderId, command.OrderItemId, cancellationToken);
            return await Task.FromResult(updatedOrder);

        }
    }
}
