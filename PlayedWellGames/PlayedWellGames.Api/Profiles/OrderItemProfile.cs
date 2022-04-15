using AutoMapper;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemGetDto>();
        }
    }
}
