using PlayedWellGames.Application;
using PlayedWellGames.Core;
using PlayedWellGames.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProduct(int id, CancellationToken cancellationToken)
        {

            var productToBeDeleted = _context.Products.FirstOrDefault(x => x.Id == id);
            if (productToBeDeleted == null) { return null; }
            _context.Products.Remove(productToBeDeleted);
            await _context.SaveChangesAsync();
            return productToBeDeleted;
        }

        public async Task<Product?> GetProductById(int id, CancellationToken cancellationToken)
        {

            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) { return null; }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return _context.Products.ToList();
        }

        public async Task<Product?> UpdateProduct(int id, Product newProduct, CancellationToken cancellationToken)
        {

            var toUpdate = _context.Products.FirstOrDefault(x => x.Id == id);
            if (toUpdate == null) { return null; }
            toUpdate.ProductName = newProduct.ProductName;
            toUpdate.Description = newProduct.Description;
            toUpdate.Price = newProduct.Price;
            toUpdate.Quantity = newProduct.Quantity;
            toUpdate.Tags = newProduct.Tags;
            toUpdate.Image = newProduct.Image;

            _context.Products.Update(toUpdate);
            await _context.SaveChangesAsync();
            return toUpdate;
        }
    }
}
