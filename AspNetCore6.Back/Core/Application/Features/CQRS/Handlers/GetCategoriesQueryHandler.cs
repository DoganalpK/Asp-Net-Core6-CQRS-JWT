using AspNetCore6.Back.Core.Application.Dtos.CategoryDto;
using AspNetCore6.Back.Core.Application.Features.CQRS.Queries;
using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Core.Domain;
using AutoMapper;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data= await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(data);
        }
    }
}
