using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDTO>().ReverseMap();
            CreateMap<Product, ProductWithCategoryDTO>();
            CreateMap<Category, CategoryWithProductsDTO>();
        }
    }
}
