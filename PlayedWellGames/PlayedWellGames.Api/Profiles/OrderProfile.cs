using AutoMapper;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.Orders.Commands;
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderGetDto>();
            CreateMap<OrderPostDto, AddOrderCommand>();
        }
    }
}
