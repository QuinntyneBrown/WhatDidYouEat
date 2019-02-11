using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WhatDidYouEat.API.Features.Identity
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator) => _mediator = mediator;

        [HttpPost("token")]
        public async Task<ActionResult<AuthenticateCommand.Response>> SignIn(AuthenticateCommand.Request request)
            => await _mediator.Send(request);
    }
}
