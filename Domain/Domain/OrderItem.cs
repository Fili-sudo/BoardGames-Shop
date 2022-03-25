using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderItem : Entity
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string ShippingAddress { get; set; }

        public OrderItem() { }
        public OrderItem(Product product, int quantity, string shippingAddress)
        {
            Product = product;
            Quantity = quantity;
            ShippingAddress = shippingAddress;
        }

        public double GetProductPrice() { return Product.Price; }
        public string GetProductName() { return Product.ProductName; }
    }
}
