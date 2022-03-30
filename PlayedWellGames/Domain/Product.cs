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
        public List<string> Tags { get; set; }

        public Product() { }
        public Product(string productName, double price, int quantity, List<string> tags)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            Tags = tags;
        }
        public Product(string productName, double price, int quantity, List<string> tags, string description)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            Tags = tags;
            Description = description;
        }
        public void AddCategory(string tag)
        {
            Tags.Add(tag);
        }
        public void RemoveCategory(string tag)
        {
            if (Tags.Contains(tag))
            {
                Tags.Remove(tag);
            }
        }
        public void UpdateCategoryName(string tag, string newCategaoryName)
        {
            int toUpdateIndex = Tags.FindIndex(x => x == tag);
            Tags.RemoveAt(toUpdateIndex);
            Tags.Insert(toUpdateIndex, newCategaoryName);
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
