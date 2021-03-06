using AutoMapper;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.OrderItems.Commands;
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemGetDto>().ReverseMap();
            //CreateMap<OrderItemPostDto, OrderItem>();
            //CreateMap<OrderItem, AddOrderItemCommand>();
            CreateMap<OrderItemPostDto, AddOrderItemCommand>();
        }
    }
}
