using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var deleteProduct = await _productRepository.DeleteProduct(command.Id, cancellationToken);
            return await Task.FromResult(deleteProduct);
        }
    }
}
