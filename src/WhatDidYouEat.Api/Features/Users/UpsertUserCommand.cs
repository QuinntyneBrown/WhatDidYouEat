using WhatDidYouEat.Core.Interfaces;
using WhatDidYouEat.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.API.Features.Users
{
    public class UpsertUserCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.User.UserId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public UserDto User { get; set; }
        }

        public class Response
        {
            public Guid UserId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var user = await _context.Users.FindAsync(request.User.UserId);

                if (user == null) {
                    user = new User();
                    _context.Users.Add(user);
                }
                

                await _context.SaveChangesAsync(cancellationToken);

                return new Response() { UserId = user.UserId };
            }
        }
    }
}
