using AspNetCore6.Back.Core.Application.Dtos.ProductDto;
using AspNetCore6.Back.Core.Application.Features.CQRS.Commands;
using AspNetCore6.Back.Core.Domain;
using AutoMapper;

namespace AspNetCore6.Back.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
            CreateMap<Product, UpdateProductCommandRequest>().ReverseMap();

            //CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
        }
    }
}
