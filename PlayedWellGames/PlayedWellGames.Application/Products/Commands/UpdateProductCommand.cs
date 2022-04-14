using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public Product NewProduct { get; set; }
    }
}
