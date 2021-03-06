using WhatDidYouEat.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.API.Features.Users
{
    public class GetUserByIdQuery
    {
        public class Request : IRequest<Response> {
            public Guid UserId { get; set; }
        }

        public class Response
        {
            public UserDto User { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
                => new Response()
                {
                    User = (await _context.Users.FindAsync(request.UserId)).ToDto()
                };
        }
    }
}
