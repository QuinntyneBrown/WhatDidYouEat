using WhatDidYouEat.Core.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.Foods
{
    public class RemoveFoodCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.FoodId).NotNull();
            }
        }

        public class Request: IRequest
        {
            public Guid FoodId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context) => _context = context;

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var food = await _context.Foods.FindAsync(request.FoodId);

                _context.Foods.Remove(food);

                await _context.SaveChangesAsync(cancellationToken);

                return new Unit();
            }
        }
    }
}
