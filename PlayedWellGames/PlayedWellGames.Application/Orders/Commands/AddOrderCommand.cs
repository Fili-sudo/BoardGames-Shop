using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Commands
{
    public class AddOrderCommand : IRequest<Order>
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public States State { get; set; }
        public double Price { get; set; }
        public ApplicationUser User { get; set; }
        public string? UserId { get; set; }
        public string ShippingAddress { get; set; }
    }
}
