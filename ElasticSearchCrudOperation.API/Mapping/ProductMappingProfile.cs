using AutoMapper;
using ElasticSearchCrudOperation.API.DTOs;
using ElasticSearchCrudOperation.API.Models;

namespace ElasticSearchCrudOperation.API.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {

            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.Feauture, opt => opt.MapFrom(src => src.Feature))
                .ReverseMap();

            CreateMap<ProductFeautureDto, ProductFeauture>().ReverseMap();

            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Feauture, opt => opt.MapFrom(src => src.Feauture))
                .ReverseMap();
        }
    }
}
