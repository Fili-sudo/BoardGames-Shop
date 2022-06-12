using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Queries
{
    public class GetAllOrdersFromUserQueryHandler : IRequestHandler<GetAllOrdersFromUserQuery, List<Order>>
    {
        private IOrderRepository _orderRepository;

        public GetAllOrdersFromUserQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> Handle(GetAllOrdersFromUserQuery query, CancellationToken cancellationToken)
        {
            return (List<Order>)await _orderRepository.GetOrdersFromUser(query.userName, cancellationToken);
        }
    }
}
