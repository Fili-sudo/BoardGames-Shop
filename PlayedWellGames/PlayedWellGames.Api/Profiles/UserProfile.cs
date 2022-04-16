using AutoMapper;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.Users.Commands;
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserPutPostDto, AddUserCommand>();
        }
    }
}
