using AspNetCore6.Back.Core.Application.Dtos.ProductDto;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest:IRequest<ProductListDto>
    {
        public int Id { get; set; }
        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
