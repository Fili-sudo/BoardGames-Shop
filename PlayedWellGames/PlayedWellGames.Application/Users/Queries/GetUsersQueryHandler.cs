using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Users.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private IUserRepository _userRepository;
        public GetUsersQueryHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<List<User>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            return (List<User>)await _userRepository.GetAllUsers(cancellationToken);
        }
    }
}
