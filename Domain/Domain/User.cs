using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class User
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Pass { get; set; }
        
    }
}
