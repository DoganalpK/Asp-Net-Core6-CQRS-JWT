using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest
    {
        public string? Definition { get; set; }
    }
}
