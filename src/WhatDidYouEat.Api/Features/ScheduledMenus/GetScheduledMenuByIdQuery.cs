using WhatDidYouEat.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.ScheduledMenus
{
    public class GetScheduledMenuByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid ScheduledMenuId { get; set; }
        }

        public class Response
        {
            public ScheduledMenuDto ScheduledMenu { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    ScheduledMenu = (await _context.ScheduledMenus.FindAsync(request.ScheduledMenuId)).ToDto()
                };
        }
    }
}
