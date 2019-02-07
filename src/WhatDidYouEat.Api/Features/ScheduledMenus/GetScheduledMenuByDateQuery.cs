using WhatDidYouEat.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WhatDidYouEat.Api.Features.ScheduledMenus
{
    public class GetScheduledMenuByDateQuery
    {
        public class Request : IRequest<Response> {
            public DateTime Date { get; set; }
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
            {
                return new Response()
                {
                    ScheduledMenu = (await _context.ScheduledMenus
                                   .Include(x => x.MenuItems).ThenInclude(x => x.Food)
                                   .Include(x => x.MenuItems).ThenInclude(x => x.MenuType)
                                   .SingleAsync(x => x.Date == request.Date)).ToDto()
                };
            }
        }
    }
}
