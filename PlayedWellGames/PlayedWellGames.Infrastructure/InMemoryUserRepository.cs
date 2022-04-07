using PlayedWellGames.Application;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> _users;

        public InMemoryUserRepository()
        {
            _users = new List<User>();
        }

        public async Task AddUser(User user, CancellationToken cancellationToken)
        {
            _users.Add(user);
        }

        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            var userToBeDeleted = _users.FirstOrDefault(x => x.Id == id);
            if (userToBeDeleted == null) { throw new Exception("User not found exception"); }
            _users.Remove(userToBeDeleted);
        }

        public async Task<User> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            if(user == null) { throw new Exception("User not found exception"); }
            return user;
        }

        public User GetUserByName(string userName)
        {
            var user = _users.FirstOrDefault(x => x.UserName == userName);
            if (user == null) { throw new Exception("User not found exception"); }
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            return _users;
        }

        public void UpdateUser(User oldUser, User newUser)
        {
            var toUpdate = _users.FirstOrDefault(x => x.Equals(oldUser));
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
