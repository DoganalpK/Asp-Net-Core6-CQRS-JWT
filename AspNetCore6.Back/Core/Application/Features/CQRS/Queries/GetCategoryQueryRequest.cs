using AspNetCore6.Back.Core.Application.Dtos.CategoryDto;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest : IRequest<CategoryListDto>
    {
        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
