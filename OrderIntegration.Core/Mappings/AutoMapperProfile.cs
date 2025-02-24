using AutoMapper;
using OrderIntegration.Core.Dtos;
using OrderIntegration.Domain.Entities;

namespace OrderIntegration.Core.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeamento de Product -> ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value)); 
        }
    }
}