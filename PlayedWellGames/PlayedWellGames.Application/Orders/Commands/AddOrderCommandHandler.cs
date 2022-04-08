using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        private IOrderRepository _orderRepository;
        public AddOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = command.Id,
                OrderItems = command.OrderItems,
                State = command.State,
                Price = command.Price,
                User = command.User,
                UserId = command.UserId,
                ShippingAddress = command.ShippingAddress
            };
            await _orderRepository.AddOrder(order, cancellationToken);

            return await Task.FromResult(order.Id);
        }
    }
}
