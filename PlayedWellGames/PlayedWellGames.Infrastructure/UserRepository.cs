using PlayedWellGames.Application;
using PlayedWellGames.Core;
using PlayedWellGames.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;

        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public UserRepository()
        {
            _users = new List<User>();
        }
        public async Task AddUser(User user, CancellationToken cancellationToken)
        {
            //_users.Add(user);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            var userToBeDeleted = _users.FirstOrDefault(x => x.Id == id);
            if (userToBeDeleted == null) { throw new Exception("User not found exception"); }
            _users.Remove(userToBeDeleted);

            //var userToBeDeleted = _context.Users.FirstOrDefault(x => x.Id == id);
            //if(userToBeDeleted == null) { throw new Exception("User not found exception"); }
            //_context.Users.Remove(userToBeDeleted);
        }

        public async Task<User> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            if(user == null) { throw new Exception("User not found exception"); }
            return user;

            //var user = _context.Users.FirstOrDefault(x => x.Id == id);
            //if (user == null) { throw new Exception("User not found exception"); }
            //return user;
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

            //return _context.Users.ToList();
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
