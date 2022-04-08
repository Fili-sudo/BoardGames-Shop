using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class AddOrderCommand : Entity, IRequest<int>
    {
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public States State { get; set; }
        public double Price { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public string ShippingAddress { get; set; }
    }
}
