using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.MenuItems
{
    [Authorize]
    [ApiController]
    [Route("api/menuItems")]
    public class MenuItemsController
    {
        private readonly IMediator _meditator;

        public MenuItemsController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMenuItemsQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMenuItemsQuery.Response>> Get()
            => await _meditator.Send(new GetMenuItemsQuery.Request());

        [HttpGet("{menuItemId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetMenuItemByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMenuItemByIdQuery.Response>> GetById(GetMenuItemByIdQuery.Request request)
            => await _meditator.Send(request);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertMenuItemCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertMenuItemCommand.Response>> Upsert(UpsertMenuItemCommand.Request request)
            => await _meditator.Send(request);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveMenuItemCommand.Request request)
            => await _meditator.Send(request);
    }
}
