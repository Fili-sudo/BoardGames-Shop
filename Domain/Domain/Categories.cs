using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Categories
    {
        public int CategoryId { get; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }

        public Categories(int CategoryId, string CategoryName, List<Product> Products)
        {
            this.CategoryId = CategoryId;
            this.CategoryName = CategoryName;
            this.Products = Products;
        }
        public Categories(int CategoryId, string CategoryName)
        {
            this.CategoryId = CategoryId;
            this.CategoryName = CategoryName;
            Products = new List<Product>();
        }
    }
}
