using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Queries
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
    {
        private IOrderItemRepository _orderItemRepository;
        public GetOrderItemByIdQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> Handle(GetOrderItemByIdQuery query, CancellationToken cancellationToken)
        {
            return await _orderItemRepository.GetOrderItemById(query.Id, cancellationToken);
        }
    }
}
