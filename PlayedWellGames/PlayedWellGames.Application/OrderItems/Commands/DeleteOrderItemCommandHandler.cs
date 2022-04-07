using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Commands
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, int>
    {
        private IOrderItemRepository _orderItemRepository;
        public DeleteOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<int> Handle(DeleteOrderItemCommand command, CancellationToken cancellationToken)
        {
            await _orderItemRepository.DeleteOrderItem(command.Id, cancellationToken);
            return await Task.FromResult(0);
        }
    }
}
