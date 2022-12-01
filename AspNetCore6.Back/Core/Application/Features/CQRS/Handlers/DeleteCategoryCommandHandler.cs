using AspNetCore6.Back.Core.Application.Features.CQRS.Commands;
using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Core.Domain;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            if (data != null)
            {
                await _repository.RemoveAsync(data);
            }
            return Unit.Value;
        }
    }
}
