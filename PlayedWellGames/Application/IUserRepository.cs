using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        User GetUserByName(string name);
        void AddUser(User user);
        void UpdateUser(User oldUser, User newUser);
        void DeleteUser(int id);

    }
}
