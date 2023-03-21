using AutoMapper;
using Domain.Data.Entities;
using Models.Dtos;

namespace Application.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.ProductCategory, opt => opt.Ignore());
        }
    }
}
