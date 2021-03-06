using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
        public Order NewOrder { get; set; }
    }
}
