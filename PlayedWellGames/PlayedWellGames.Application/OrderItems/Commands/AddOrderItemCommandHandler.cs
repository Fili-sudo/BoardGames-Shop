using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Commands
{
    public class AddOrderItemCommandHandler : IRequestHandler<AddOrderItemCommand, int>
    {
        private IOrderItemRepository _orderItemRepository;
        public AddOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<int> Handle(AddOrderItemCommand command, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItem
            {
                Id = command.Id,
                Product = command.Product,
                ProductId = command.ProductId,
                Quantity = command.Quantity
            };

            await _orderItemRepository.AddOrderItem(orderItem, cancellationToken);

            return await Task.FromResult(orderItem.Id);
        }
    }
}
