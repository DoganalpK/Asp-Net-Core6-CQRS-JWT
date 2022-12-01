using AspNetCore6.Back.Core.Application.Features.CQRS.Commands;
using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Core.Domain;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x=> x.Id == request.Id);
            if (data != null)
            {
                data.Definition = request.Definition;
                await _repository.UpdateAsync(data);
            }
            return Unit.Value;
        }
    }
}
