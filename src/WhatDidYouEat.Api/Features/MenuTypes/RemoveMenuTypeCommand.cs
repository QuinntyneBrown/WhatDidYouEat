using WhatDidYouEat.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.MenuTypes
{
    public class RemoveMenuTypeCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.MenuTypeId).NotNull();
            }
        }

        public class Request: IRequest
        {
            public Guid MenuTypeId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var menuType = await _context.MenuTypes.FindAsync(request.MenuTypeId);

                _context.MenuTypes.Remove(menuType);

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}
