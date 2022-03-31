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

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void DeleteUser(int id)
        {
            User userToBeDeleted = _users.FirstOrDefault(x => x.Id == id);
            if (userToBeDeleted == null) { throw new Exception("User not found exception"); }
            _users.Remove(userToBeDeleted);
        }

        public User GetUserById(int id)
        {
            foreach(User user in _users)
            {
                if (user.Id == id) { return user; }
            }
            throw new Exception("User not found exception");
        }

        public User GetUserByName(string userName)
        {
            foreach (User user in _users)
            {
                if (user.UserName == userName) { return user; }
            }
            throw new Exception("User not found exception");
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public void UpdateUser(User oldUser, User newUser)
        {
            User toUpdate = _users.FirstOrDefault(x => x.Equals(oldUser));
            if (toUpdate == null) { throw new Exception("User not found exception"); }
            toUpdate.FirstName = newUser.FirstName;
            toUpdate.LastName = newUser.LastName;
            toUpdate.UserName = newUser.UserName;
            toUpdate.Pass = newUser.Pass;
            toUpdate.Address = newUser.Address;
            toUpdate.Mail = newUser.Mail;
            toUpdate.Phone = newUser.Phone;

        }
    }
}
