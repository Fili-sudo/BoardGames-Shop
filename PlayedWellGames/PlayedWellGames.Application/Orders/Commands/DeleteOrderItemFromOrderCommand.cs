using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class DeleteOrderItemFromOrderCommand : IRequest<Order>
    {
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
    }
}
