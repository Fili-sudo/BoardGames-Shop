using MediatR;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayedWellGames.Application.Users.Querries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public  async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(query.Id, cancellationToken);
        }
    }
}
