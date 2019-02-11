using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace WhatDidYouEat.API.Features.Users
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UsersController
    {
        private readonly IMediator _meditator;

        public UsersController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetUsersQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUsersQuery.Response>> Get()
            => await _meditator.Send(new GetUsersQuery.Request());

        [HttpGet("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetUserByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUserByIdQuery.Response>> GetById(GetUserByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertUserCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertUserCommand.Response>> Upsert(UpsertUserCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveUserCommand.Request request)
            => await _meditator.Send(request);
    }
}
