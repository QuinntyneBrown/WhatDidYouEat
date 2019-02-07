using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.ScheduledMenus
{
    [Authorize]
    [ApiController]
    [Route("api/scheduledMenus")]
    public class ScheduledMenusController
    {
        private readonly IMediator _meditator;

        public ScheduledMenusController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetScheduledMenusQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetScheduledMenusQuery.Response>> Get()
            => await _meditator.Send(new GetScheduledMenusQuery.Request());

        [HttpGet("{scheduledMenuId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetScheduledMenuByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetScheduledMenuByIdQuery.Response>> GetById(GetScheduledMenuByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpGet("date/{date}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetScheduledMenuByDateQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetScheduledMenuByDateQuery.Response>> GetByDate([FromQuery]GetScheduledMenuByDateQuery.Request request)
            => await _meditator.Send(request);

        [HttpGet("today")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetScheduledMenuByDateQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetScheduledMenuByDateQuery.Response>> GetToday()
            => await _meditator.Send(new GetScheduledMenuByDateQuery.Request { Date = DateTime.Now });
        
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertScheduledMenuCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertScheduledMenuCommand.Response>> Upsert(UpsertScheduledMenuCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveScheduledMenuCommand.Request request)
            => await _meditator.Send(request);
    }
}
