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

        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddUser(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            var userToBeDeleted = _context.Users.FirstOrDefault(x => x.Id == id);
            if(userToBeDeleted == null) { throw new Exception("User not found exception"); }
            _context.Users.Remove(userToBeDeleted);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) { return null; }
            return user;
        }

        public async Task<User> GetUserByName(string userName, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null) { return null; }
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            return _context.Users.ToList();
        }

        public async Task UpdateUser(int id, User newUser, CancellationToken cancellationToken)
        {

            var toUpdate = _context.Users.FirstOrDefault(x => x.Id == id);
            if (toUpdate == null) { throw new Exception("User not found exception"); }
            toUpdate.FirstName = newUser.FirstName;
            toUpdate.LastName = newUser.LastName;
            toUpdate.UserName = newUser.UserName;
            toUpdate.Pass = newUser.Pass;
            toUpdate.Address = newUser.Address;
            toUpdate.Mail = newUser.Mail;
            toUpdate.Phone = newUser.Phone;

            _context.Users.Update(toUpdate);
            await _context.SaveChangesAsync();

        }
    }
}
