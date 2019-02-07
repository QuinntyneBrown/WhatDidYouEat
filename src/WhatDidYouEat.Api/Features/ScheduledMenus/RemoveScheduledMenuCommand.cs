using WhatDidYouEat.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.ScheduledMenus
{
    public class RemoveScheduledMenuCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ScheduledMenuId).NotNull();
            }
        }

        public class Request: IRequest
        {
            public Guid ScheduledMenuId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var scheduledMenu = await _context.ScheduledMenus.FindAsync(request.ScheduledMenuId);

                _context.ScheduledMenus.Remove(scheduledMenu);

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}
