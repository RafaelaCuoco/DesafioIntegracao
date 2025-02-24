using AutoMapper;
using OrderIntegration.Core.Dtos;
using OrderIntegration.Domain.Entities;

namespace OrderIntegration.Core.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeamento de User -> OrderResponseDto
            CreateMap<User, OrderResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));

            // Mapeamento de Order -> OrderDto
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total.ToString("F10")))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            // Mapeamento de Product -> ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value.ToString("F10")));
        }
    }
}