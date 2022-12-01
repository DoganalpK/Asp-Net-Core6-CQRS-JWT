using AspNetCore6.Back.Core.Application.Dtos.CategoryDto;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
