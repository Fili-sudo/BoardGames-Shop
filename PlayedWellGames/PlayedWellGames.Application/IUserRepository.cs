using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken);
        Task<User> GetUserById(int id, CancellationToken cancellationToken);
        Task<User> GetUserByName(string userName, CancellationToken cancellationToken);
        Task AddUser(User user, CancellationToken cancellationToken);
        Task UpdateUser(int id, User newUser, CancellationToken cancellationToken);
        Task DeleteUser(int id, CancellationToken cancellationToken);

    }
}
