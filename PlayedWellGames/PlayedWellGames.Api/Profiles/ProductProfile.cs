using AutoMapper;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.Products.Commands;
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductPutPostDto, AddProductCommand>();
        }
    }
}
