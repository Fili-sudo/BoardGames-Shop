using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Order>
    {
        private IOrderRepository _orderRepository;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var deletedOrder = await _orderRepository.DeleteOrder(command.Id, cancellationToken);

            return await Task.FromResult(deletedOrder);
        }
    }
}
