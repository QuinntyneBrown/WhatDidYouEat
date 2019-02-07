using WhatDidYouEat.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.MenuItems
{
    public class RemoveMenuItemCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.MenuItemId).NotNull();
            }
        }

        public class Request: IRequest
        {
            public Guid MenuItemId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var menuItem = await _context.MenuItems.FindAsync(request.MenuItemId);

                _context.MenuItems.Remove(menuItem);

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}
