using WhatDidYouEat.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.MenuTypes
{
    public class GetMenuTypeByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid MenuTypeId { get; set; }
        }

        public class Response
        {
            public MenuTypeDto MenuType { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    MenuType = (await _context.MenuTypes.FindAsync(request.MenuTypeId)).ToDto()
                };
        }
    }
}
