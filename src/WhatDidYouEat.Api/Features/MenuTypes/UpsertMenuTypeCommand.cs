using WhatDidYouEat.Core.Interfaces;
using WhatDidYouEat.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.MenuTypes
{
    public class UpsertMenuTypeCommand
    {

        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.MenuType.MenuTypeId).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public MenuTypeDto MenuType { get; set; }
        }

        public class Response
        {
            public Guid MenuTypeId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var menuType = await _context.MenuTypes.FindAsync(request.MenuType.MenuTypeId);

                if (menuType == null) {
                    menuType = new MenuType();
                    _context.MenuTypes.Add(menuType);
                }

                menuType.Name = request.MenuType.Name;
                menuType.Description = request.MenuType.Description;
                menuType.OrderIndex = request.MenuType.OrderIndex;

                await _context.SaveChangesAsync(cancellationToken);

                return new Response() { MenuTypeId = menuType.MenuTypeId };
            }
        }
    }
}
