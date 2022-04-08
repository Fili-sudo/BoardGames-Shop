using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Queries
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<Order>>
    {
        private IOrderRepository _orderRepository;
        public GetAllOrdersQueryHandler(IOrderRepository _orderRepository)
        {
            _orderRepository = _orderRepository;
        }

        public Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
