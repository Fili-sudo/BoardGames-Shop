using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class DeleteOrderItemFromOrderCommandHandler : IRequestHandler<DeleteOrderItemFromOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderItemFromOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(DeleteOrderItemFromOrderCommand command, CancellationToken cancellationToken)
        {
            var updatedOrder = await _orderRepository.RemoveOrderItemFromOrder(command.OrderId, command.OrderItemId, cancellationToken);
            return await Task.FromResult(updatedOrder);
        }
    }
}
