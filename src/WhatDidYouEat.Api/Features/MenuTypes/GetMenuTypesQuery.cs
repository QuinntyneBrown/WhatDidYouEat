using WhatDidYouEat.Core.Interfaces;
using WhatDidYouEat.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WhatDidYouEat.Api.Features.MenuTypes
{
    public class GetMenuTypesQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public IEnumerable<MenuTypeDto> MenuTypes { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                =>  new Response()
                {
                    MenuTypes = await _context.MenuTypes.Select(x => x.ToDto()).ToArrayAsync()
                };
        }
    }
}
