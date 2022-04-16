using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken);
        Task<Product> GetProductById(int id, CancellationToken cancellationToken);
        Task<Product> AddProduct(Product product, CancellationToken cancellationToken);
        Task<Product> UpdateProduct(int Id, Product newProduct, CancellationToken cancellationToken);
        Task<Product> DeleteProduct(int id, CancellationToken cancellationToken);
    }
}
