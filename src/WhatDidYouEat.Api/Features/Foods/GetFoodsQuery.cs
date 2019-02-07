using WhatDidYouEat.Core.Interfaces;
using WhatDidYouEat.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WhatDidYouEat.Api.Features.Foods
{
    public class GetFoodsQuery
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public IEnumerable<FoodDto> Foods { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                =>  new Response()
                {
                    Foods = await _context.Foods.Select(x => x.ToDto()).ToArrayAsync(cancellationToken)
                };
        }
    }
}
