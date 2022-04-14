using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class UpdateOrderStateCommandHandler : IRequestHandler<UpdateOrderStateCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderStateCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(UpdateOrderStateCommand command, CancellationToken cancellationToken)
        {
            await _orderRepository.UpdateOrderState(command.Id, command.NewState, cancellationToken);
            return (int)await Task.FromResult(command.NewState);
        }
    }
}
