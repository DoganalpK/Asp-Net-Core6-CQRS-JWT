using AspNetCore6.Back.Core.Application.Features.CQRS.Commands;
using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Core.Domain;
using AutoMapper;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<Product>(request);
            await _repository.CreateAsync(dto);
            return Unit.Value;
        }
    }
}
