using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Users.Commands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private IUserRepository _userRepository;
        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User 
            { 
                Id = command.Id, 
                UserName = command.UserName,
                Pass = command.Pass,
                FirstName = command.FirstName, 
                LastName = command.LastName,
                Address = command.Address,
                Mail = command.Mail,
                Phone = command.Phone,
                Role = command.Role
            };
            _userRepository.AddUser(user, cancellationToken);

            return await Task.FromResult(user.Id);
        }
    }
}
