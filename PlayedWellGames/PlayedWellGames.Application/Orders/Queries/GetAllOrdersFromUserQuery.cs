using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Orders.Queries
{
    public class GetAllOrdersFromUserQuery : IRequest<List<Order>>
    {
       public string userName { get; set; }
    }
}
