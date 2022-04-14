using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Commands
{
    public class UpdateOrderItemQuantityCommandHandler : IRequestHandler<UpdateOrderItemQuantityCommand, int>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public UpdateOrderItemQuantityCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<int> Handle(UpdateOrderItemQuantityCommand command, CancellationToken cancellationToken)
        {
            await _orderItemRepository.UpdateOrderItemQuantity(command.Id, command.newQuantity, cancellationToken);
            return await Task.FromResult(command.Id);
        }
    }

       
}

