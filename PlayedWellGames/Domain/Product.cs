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
        public List<Categories> Categories { get; set; }

        public Product() { }
        public Product(string productName, double price, int quantity, List<Categories> categories)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            Categories = categories;
        }
        public Product(string productName, double price, int quantity, List<Categories> categories, string description)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            Categories = categories;
            Description = description;
        }
        public void AddCategory(Categories category)
        {
            Categories.Add(category);
        }
        public void RemoveCategory(Categories category)
        {
            if (Categories.Contains(category))
            {
                Categories.Remove(category);
            }
        }
        public void UpdateCategoryName(Categories category, string newName)
        {
            Categories toUpdate = Categories.FirstOrDefault(x => x == category);
            if(toUpdate != null)
            {
                toUpdate.CategoryName = newName;
            }
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
