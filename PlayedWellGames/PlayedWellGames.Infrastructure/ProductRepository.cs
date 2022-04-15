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
        private List<Product> _products;

        private AppDbContext _context;

        public ProductRepository()
        {
            _products = new List<Product>();
        }
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product, CancellationToken cancellationToken)
        {
            //_products.Add(product);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id, CancellationToken cancellationToken)
        {
            //var productToBeDeleted = _products.FirstOrDefault(x => x.Id == id);
            //if (productToBeDeleted == null) { throw new Exception("Product not found exception"); }
            //_products.Remove(productToBeDeleted);

            var productToBeDeleted = _context.Products.FirstOrDefault(x => x.Id == id);
            if (productToBeDeleted == null) { throw new Exception("Product not found exception"); }
            _context.Products.Remove(productToBeDeleted);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductById(int id, CancellationToken cancellationToken)
        {
            //var product = _products.FirstOrDefault(x => x.Id == id);
            //if(product == null) { throw new Exception("Product not found exception"); }
            //return product;

            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) { return null; }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken)
        {
            //return _products;

            return _context.Products.ToList();
        }

        public async Task UpdateProduct(int id, Product newProduct, CancellationToken cancellationToken)
        {
            //var toUpdate = _products.FirstOrDefault(x => x.Id == id);
            //if (toUpdate == null) { throw new Exception("Product not found exception"); }
            //toUpdate.ProductName = newProduct.ProductName;
            //toUpdate.Description = newProduct.Description;
            //toUpdate.Price = newProduct.Price;
            //toUpdate.Quantity = newProduct.Quantity;
            //toUpdate.Tags = newProduct.Tags;

            var toUpdate = _context.Products.FirstOrDefault(x => x.Id == id);
            if (toUpdate == null) { throw new Exception("Product not found exception"); }
            toUpdate.ProductName = newProduct.ProductName;
            toUpdate.Description = newProduct.Description;
            toUpdate.Price = newProduct.Price;
            toUpdate.Quantity = newProduct.Quantity;
            toUpdate.Tags = newProduct.Tags;

            _context.Products.Update(toUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
