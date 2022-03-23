using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RegularUser : User
    {
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
    }
}
