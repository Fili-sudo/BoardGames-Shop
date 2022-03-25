using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ShoppingCart
    {
        public List<OrderItem> Items { get; set; }

        public ShoppingCart(List<OrderItem> items)
        {
            Items = items;
        }
        public void AddProductToCart(Product product, int quantity)
        { 
            if (Items.Any(item => item.GetProductName() == product.ProductName))
            {
                quantity = quantity + 1;
            }
            OrderItem orderItem = new OrderItem(product, quantity);
            Items.Add(orderItem);
        }
    }
}
