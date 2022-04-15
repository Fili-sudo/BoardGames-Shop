using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Products.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private IProductRepository _productRepository;
        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = command.Id,
                ProductName = command.ProductName,
                Description = command.Description,
                Price = command.Price,
                Quantity = command.Quantity,
                Tags = command.Tags
            };

            var createdProduct = await _productRepository.AddProduct(product, cancellationToken);

            return await Task.FromResult(createdProduct);
        }
    }
}
