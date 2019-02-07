using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.MenuTypes
{
    [Authorize]
    [ApiController]
    [Route("api/menuTypes")]
    public class MenuTypesController
    {
        private readonly IMediator _meditator;

        public MenuTypesController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMenuTypesQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMenuTypesQuery.Response>> Get()
            => await _meditator.Send(new GetMenuTypesQuery.Request());

        [HttpGet("{menuTypeId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMenuTypeByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMenuTypeByIdQuery.Response>> GetById(GetMenuTypeByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertMenuTypeCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertMenuTypeCommand.Response>> Upsert(UpsertMenuTypeCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveMenuTypeCommand.Request request)
            => await _meditator.Send(request);
    }
}
