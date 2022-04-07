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
        Product GetProductById(int id);
        Task AddProduct(Product product, CancellationToken cancellationToken);
        void UpdateProduct(Product oldProduct, Product newProduct);
        void DeleteProduct(int id);
    }
}
