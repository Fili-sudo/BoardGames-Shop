using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.OrderItems.Commands
{
    public class UpdateOrderItemQuantityCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int newQuantity { get; set; }
    }
}
