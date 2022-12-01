using AspNetCore6.Back.Core.Application.Dtos.CategoryDto;
using AspNetCore6.Back.Core.Application.Features.CQRS.Commands;
using AspNetCore6.Back.Core.Application.Interfaces;
using AspNetCore6.Back.Core.Domain;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Category
            {
                Definition = request.Definition,
            });
            return Unit.Value;
        }
    }
}
