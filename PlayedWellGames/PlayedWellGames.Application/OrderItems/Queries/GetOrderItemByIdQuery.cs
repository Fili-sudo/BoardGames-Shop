using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Queries
{
    public class GetOrderItemByIdQuery : IRequest<OrderItem>
    {
        public int Id { get; set; }
    }
}
