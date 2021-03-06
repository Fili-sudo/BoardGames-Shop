using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }

        public User NewUser { get; set; }
    }
}
