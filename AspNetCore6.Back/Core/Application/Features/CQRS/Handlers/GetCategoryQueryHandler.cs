using AspNetCore6.Back.Core.Application.Dtos.CategoryDto;
using AspNetCore6.Back.Core.Application.Features.CQRS.Queries;
using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Core.Domain;
using AutoMapper;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x=> x.Id == request.Id);
            return _mapper.Map<CategoryListDto>(data);
        }
    }
}
