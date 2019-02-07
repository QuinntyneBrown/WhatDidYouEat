using WhatDidYouEat.Core.Interfaces;
using WhatDidYouEat.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.MenuItems
{
    public class UpsertMenuItemCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.MenuItem.MenuItemId).NotNull();
                RuleFor(request => request.MenuItem.MenuTypeId).NotNull();
                RuleFor(request => request.MenuItem.FoodId).NotNull();
                RuleFor(request => request.MenuItem.ScheduledMenuId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public MenuItemDto MenuItem { get; set; }
        }

        public class Response
        {
            public Guid MenuItemId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var menuItem = await _context.MenuItems.FindAsync(request.MenuItem.MenuItemId);

                if (menuItem == null) {
                    menuItem = new MenuItem();
                    _context.MenuItems.Add(menuItem);
                }

                menuItem.MenuTypeId = request.MenuItem.MenuTypeId;

                menuItem.FoodId = request.MenuItem.FoodId;

                menuItem.ScheduledMenuId = request.MenuItem.ScheduledMenuId;

                await _context.SaveChangesAsync(cancellationToken);

                return new Response() { MenuItemId = menuItem.MenuItemId };
            }
        }
    }
}
