using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ShoppingCart : Entity
    {
        public List<OrderItem> Items { get; set; }

        public ShoppingCart(List<OrderItem> items)
        {
            Items = items;
        }
        
    }
}
