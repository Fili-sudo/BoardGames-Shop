using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class User
    {
        public int UserId { get; }
        public string userName { get; set; }
        public string Pass { get; set; }

        public User(int UserId, string userName, string Pass)
        {
            this.UserId = UserId;
            this.userName = userName;
            this.Pass = Pass;
        }
        
    }
}
