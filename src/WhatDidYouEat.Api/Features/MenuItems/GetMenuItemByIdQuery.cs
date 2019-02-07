using WhatDidYouEat.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.MenuItems
{
    public class GetMenuItemByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid MenuItemId { get; set; }
        }

        public class Response
        {
            public MenuItemDto MenuItem { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    MenuItem = (await _context.MenuItems.FindAsync(request.MenuItemId)).ToDto()
                };
        }
    }
}
