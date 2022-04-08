using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
    {
        private IOrderRepository _orderRepository;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            await _orderRepository.DeleteOrder(command.Id, cancellationToken);

            return await Task.FromResult(0);
        }
    }
}
