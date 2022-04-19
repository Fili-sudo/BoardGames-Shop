﻿using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Users.Queries
{
    public class GetUserByUserNameQuery : IRequest<User>
    {
        public string UserName { get; set; }
    }
}
