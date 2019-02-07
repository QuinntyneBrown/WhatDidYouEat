using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WhatDidYouEat.Core.Interfaces;

namespace WhatDidYouEat.Api.Features.Foods
{
    public class GetFoodByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid FoodId { get; set; }
        }

        public class Response
        {
            public FoodDto Food { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) 
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    Food = (await _context.Foods.FindAsync(request.FoodId, cancellationToken)).ToDto()
                };
        }
    }
}
