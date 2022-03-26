using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : Entity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public List<string> Categories { get; set; }

        public Product() { }
        public Product(string productName, double price, int quantity, List<string> categories)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            Categories = categories;
        }
        public Product(string productName, double price, int quantity, List<string> categories, string description)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            Categories = categories;
            Description = description;
        }
        public void AddCategory(string category)
        {
            Categories.Add(category);
        }
        public void RemoveCategory(string category)
        {
            if (Categories.Contains(category))
            {
                Categories.Remove(category);
            }
        }
        public void UpdateCategoryName(string category, string newCategaoryName)
        {
            int toUpdateIndex = Categories.FindIndex(x => x == category);
            Categories.RemoveAt(toUpdateIndex);
            Categories.Insert(toUpdateIndex, newCategaoryName);
        }
        public void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }
        public void decreaseQuantity(int quantity)
        {
            Quantity -= quantity;
        }



    }
}
