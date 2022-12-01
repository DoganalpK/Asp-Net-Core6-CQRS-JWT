using AspNetCore6.Back.Core.Application.Features.CQRS.Commands;
using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Core.Domain;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
                await _repository.RemoveAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
