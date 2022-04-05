using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Users.Querries
{
    public class GetUsersQuerryHandler : IRequestHandler<GetUsersQuerry, List<User>>
    {
        private IUserRepository _userRepository;
        public GetUsersQuerryHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<List<User>> Handle(GetUsersQuerry request, CancellationToken cancellationToken)
        {
            return (List<User>)await _userRepository.GetAllUsers(cancellationToken);
        }
    }
}
