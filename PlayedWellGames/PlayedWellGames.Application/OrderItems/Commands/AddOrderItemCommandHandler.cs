using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Commands
{
    public class AddOrderItemCommandHandler : IRequestHandler<AddOrderItemCommand, OrderItem>
    {
        private IOrderItemRepository _orderItemRepository;
        public AddOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> Handle(AddOrderItemCommand command, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItem
            {
                Id = command.Id,
                Product = command.Product,
                ProductId = command.ProductId,
                Quantity = command.Quantity
            };

            var createdOrderItem = await _orderItemRepository.AddOrderItem(orderItem, cancellationToken);

            return await Task.FromResult(createdOrderItem);
        }
    }
}
