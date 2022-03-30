using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        List<User> _users;

        public InMemoryUserRepository()
        {
            _users = new List<User>();
        }

        void IUserRepository.AddUser(User user)
        {
            _users.Add(user);
        }

        void IUserRepository.DeleteUser(int id)
        {
            foreach (User user in _users)
            {
                if (user.Id == id) { _users.Remove(user); }
            }
        }

        User IUserRepository.GetUserById(int id)
        {
            foreach(User user in _users)
            {
                if (user.Id == id) { return user; }
            }
            throw new Exception("User not found exception");
        }

        User IUserRepository.GetUserByName(string userName)
        {
            foreach (User user in _users)
            {
                if (user.UserName == userName) { return user; }
            }
            throw new Exception("User not found exception");
        }

        IEnumerable<User> IUserRepository.GetUsers()
        {
            return _users;
        }

        void IUserRepository.UpdateUser(User oldUser, User newUser)
        {
            foreach (User user in _users)
            {
                if(user.Equals(oldUser)) { oldUser = newUser; }
            }
        }
    }
}
