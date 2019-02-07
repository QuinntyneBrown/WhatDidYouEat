using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.Foods
{
    [Authorize]
    [ApiController]
    [Route("api/foods")]
    public class FoodsController
    {
        private readonly IMediator _meditator;

        public FoodsController(IMediator mediator) => _meditator = mediator;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetFoodsQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetFoodsQuery.Response>> Get(CancellationToken cancellationToken)
            => await _meditator.Send(new GetFoodsQuery.Request(), cancellationToken);

        [HttpGet("{foodId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetFoodByIdQuery.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetFoodByIdQuery.Response>> GetById(GetFoodByIdQuery.Request request, CancellationToken cancellationToken)
            => await _meditator.Send(request, cancellationToken);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpsertFoodCommand.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpsertFoodCommand.Response>> Upsert(UpsertFoodCommand.Request request, CancellationToken cancellationToken)
            => await _meditator.Send(request, cancellationToken);

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> Remove([FromQuery]RemoveFoodCommand.Request request, CancellationToken cancellationToken)
            => await _meditator.Send(request, cancellationToken);
    }
}
