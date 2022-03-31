using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryProductRepository : IProductRepository
    {
        private List<Product> _products;

        public InMemoryProductRepository()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            Product productToBeDeleted = _products.FirstOrDefault(x => x.Id == id);
            if (productToBeDeleted == null) { throw new Exception("Product not found exception"); }
            _products.Remove(productToBeDeleted);
        }

        public Product GetProductById(int id)
        {
            foreach (Product product in _products)
            {
                if (product.Id == id) { return product; }
            }
            throw new Exception("Product not found exception");
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public void UpdateProduct(Product oldProduct, Product newProduct)
        {
            Product toUpdate = _products.FirstOrDefault(x => x.Equals(oldProduct));
            if (toUpdate == null) { throw new Exception("User not found exception"); }
            toUpdate.ProductName = newProduct.ProductName;
            toUpdate.Description = newProduct.Description;
            toUpdate.Price = newProduct.Price;
            toUpdate.Quantity = newProduct.Quantity;
            toUpdate.Tags = newProduct.Tags;
        }
    }
}
