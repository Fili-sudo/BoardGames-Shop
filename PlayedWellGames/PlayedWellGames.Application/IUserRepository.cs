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
        public Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken);
        User GetUserById(int id);
        User GetUserByName(string userName);
        void AddUser(User user);
        void UpdateUser(User oldUser, User newUser);
        void DeleteUser(int id);

    }
}
