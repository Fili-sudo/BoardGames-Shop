using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class UpdateOrderItemFromOrderCommandHandler : IRequestHandler<UpdateOrderItemFromOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderItemFromOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(UpdateOrderItemFromOrderCommand command, CancellationToken cancellationToken)
        {
            var updatedOrder = await _orderRepository.UpdateOrderItemFromOrder(command.OrderId, command.OrderItemId, command.NewQuantity, cancellationToken);
            return await Task.FromResult(updatedOrder);
        }
    }
}
