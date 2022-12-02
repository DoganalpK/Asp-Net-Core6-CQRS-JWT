using AspNetCore6.Back.Core.Application.Features.CQRS.Commands;
using AspNetCore6.Back.Core.Application.Features.CQRS.Queries;
using AspNetCore6.Back.Core.Domain;
using AspNetCore6.Back.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace AspNetCore6.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created(string.Empty, request);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(CheckUserQueryRequest request)
        {
            var userDto = await _mediator.Send(request);
            if (userDto.IsExist)
            {
                var token = JwtTokenGeneretor.GenerateToken(userDto);
                return Created(string.Empty, token);
            }
            return BadRequest("Username or password is wrong!");
        }
    }
}
