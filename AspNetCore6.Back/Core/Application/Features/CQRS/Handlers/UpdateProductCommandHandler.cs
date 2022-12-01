using AspNetCore6.Back.Core.Application.Features.CQRS.Commands;
using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Core.Domain;
using AutoMapper;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updated = await _repository.GetByIdAsync(request.Id);
            if (updated != null)
            {
                var dto = _mapper.Map<Product>(request);
                await _repository.UpdateAsync(dto);
            }
            return Unit.Value;
        }
    }
}
