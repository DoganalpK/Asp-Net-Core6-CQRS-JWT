using AspNetCore6.Back.Core.Application.Dtos.ProductDto;
using AspNetCore6.Back.Core.Application.Features.CQRS.Queries;
using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Core.Domain;
using AutoMapper;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductListDto>>(data);
        }
    }
}
