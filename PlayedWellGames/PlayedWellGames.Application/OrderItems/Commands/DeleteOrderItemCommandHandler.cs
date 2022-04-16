using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Commands
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, OrderItem>
    {
        private IOrderItemRepository _orderItemRepository;
        public DeleteOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> Handle(DeleteOrderItemCommand command, CancellationToken cancellationToken)
        {
            var deletedOrderItem = await _orderItemRepository.DeleteOrderItem(command.Id, cancellationToken);
            return await Task.FromResult(deletedOrderItem);
        }
    }
}
