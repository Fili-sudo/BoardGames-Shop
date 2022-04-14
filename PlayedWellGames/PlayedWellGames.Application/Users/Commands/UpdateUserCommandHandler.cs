using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateUser(command.Id, command.NewUser, cancellationToken);
            return await Task.FromResult(command.NewUser);
        }
    }
}
