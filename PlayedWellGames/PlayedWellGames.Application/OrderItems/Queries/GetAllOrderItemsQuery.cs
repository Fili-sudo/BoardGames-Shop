using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Queries
{
    public class GetAllOrderItemsQuery : IRequest<List<OrderItem>>
    {
    }
}
