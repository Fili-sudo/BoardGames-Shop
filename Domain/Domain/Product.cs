using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public static int Quantity { get; set; }




    }
}
