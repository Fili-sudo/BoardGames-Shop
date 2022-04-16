using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Commands
{
    public class UpdateOrderItemQuantityCommandHandler : IRequestHandler<UpdateOrderItemQuantityCommand, OrderItem>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public UpdateOrderItemQuantityCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> Handle(UpdateOrderItemQuantityCommand command, CancellationToken cancellationToken)
        {
            var updatedOrderItem = await _orderItemRepository.UpdateOrderItemQuantity(command.Id, command.newQuantity, cancellationToken);
            return await Task.FromResult(updatedOrderItem);
        }
    }

       
}

