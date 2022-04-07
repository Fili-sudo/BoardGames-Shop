﻿using PlayedWellGames.Core;
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
        Task<User> GetUserById(int id, CancellationToken cancellationToken) ;
        User GetUserByName(string userName);
        Task AddUser(User user, CancellationToken cancellationToken);
        void UpdateUser(User oldUser, User newUser);
        Task DeleteUser(int id, CancellationToken cancellationToken);

    }
}