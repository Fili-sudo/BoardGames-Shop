using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Core
{
    public class OrderItem : Entity
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderItem() { }
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not OrderItem) return false;
            OrderItem other = (OrderItem) obj;
            return other.Id == Id;

        }
        public override int GetHashCode()
        {
            return Id;
        }
        public override string ToString()
        {
            return $"{Quantity} {Product.ProductName}";
        }
        public double GetProductPrice() { return Product.Price; }
        public string GetProductName() { return Product.ProductName; }
    }
}
