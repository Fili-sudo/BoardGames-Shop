using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Categories : Entity
    {
        public string CategoryName { get; set; }

        public Categories() { }
        public Categories(string categoryName) 
        {
            CategoryName = categoryName;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Categories other = (Categories)obj;
            return CategoryName.Equals(other.CategoryName) && Id == other.Id;
        }

    }
}
