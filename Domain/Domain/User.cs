using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class User
    {
        public readonly int id;
        public int Id
        {
            get { return id; }
        }
        public string Name { get; set; }
        public string Pass { get; set; }
        
    }
}
