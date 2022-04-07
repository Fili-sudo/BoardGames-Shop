using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Queries
{
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, List<OrderItem>>
    {
        private IOrderItemRepository _orderItemRepository;
        public GetAllOrderItemsQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<List<OrderItem>> Handle(GetAllOrderItemsQuery query, CancellationToken cancellationToken)
        {
            return (List<OrderItem>)await _orderItemRepository.GetOrderItems(cancellationToken);
        }
    }
}
