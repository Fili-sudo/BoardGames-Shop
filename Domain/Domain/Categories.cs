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

    }
}
