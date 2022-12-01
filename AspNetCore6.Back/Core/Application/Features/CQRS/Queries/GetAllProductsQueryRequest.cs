using AspNetCore6.Back.Core.Application.Dtos.ProductDto;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest : IRequest<List<ProductListDto>>
    {
    }
}
