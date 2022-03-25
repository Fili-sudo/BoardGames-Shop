using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int ProductId { get; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public static int Quantity { get; set; }

        public Product(int ProductId, string ProductName, double Price)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.Price = Price;
            Quantity++;
        }
        public Product(int ProductId, string ProductName, double Price, int Quantity)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.Price = Price;
            Product.Quantity = Quantity;
        }



    }
}
