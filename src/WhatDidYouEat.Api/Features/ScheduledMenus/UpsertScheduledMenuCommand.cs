using WhatDidYouEat.Core.Interfaces;
using WhatDidYouEat.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.ScheduledMenus
{
    public class UpsertScheduledMenuCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.ScheduledMenu.ScheduledMenuId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public ScheduledMenuDto ScheduledMenu { get; set; }
        }

        public class Response
        {
            public Guid ScheduledMenuId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var scheduledMenu = await _context.ScheduledMenus.FindAsync(request.ScheduledMenu.ScheduledMenuId);

                if (scheduledMenu == null) {
                    scheduledMenu = new ScheduledMenu();
                    _context.ScheduledMenus.Add(scheduledMenu);
                }
                
                await _context.SaveChangesAsync(cancellationToken);

                return new Response() { ScheduledMenuId = scheduledMenu.ScheduledMenuId };
            }
        }
    }
}
