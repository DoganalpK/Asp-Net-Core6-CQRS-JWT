using AspNetCore6.Back.Core.Application.Dtos.CategoryDto;
using AspNetCore6.Back.Core.Application.Features.CQRS.Commands;
using AspNetCore6.Back.Core.Domain;
using AutoMapper;

namespace AspNetCore6.Back.Core.Application.Mappings
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
            //CreateMap<Category, CategoryCreateDto>().ReverseMap();
            //CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
        }
    }
}
