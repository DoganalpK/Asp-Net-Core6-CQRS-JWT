using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteCategoryCommandRequest : IRequest
    {

        public DeleteCategoryCommandRequest(int ıd)
        {
            Id = ıd;
        }
        public int Id { get; set; }
    }
}
