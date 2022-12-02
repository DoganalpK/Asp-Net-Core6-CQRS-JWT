using AspNetCore6.Back.Core.Application.Dtos.UserDto;
using MediatR;

namespace AspNetCore6.Back.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
