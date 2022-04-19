using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Users.Queries
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByUserNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByUserNameQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByName(query.UserName, cancellationToken);
        }
    }
}
