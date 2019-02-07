using WhatDidYouEat.Core.Interfaces;
using WhatDidYouEat.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatDidYouEat.Api.Features.Foods
{
    public class UpsertFoodCommand
    {
        public class Validator: AbstractValidator<Request> {
            public Validator()
            {
                RuleFor(request => request.Food.FoodId).NotNull();
                RuleFor(request => request.Food.Name).NotNull();
            }
        }

        public class Request : IRequest<Response> {
            public FoodDto Food { get; set; }
        }

        public class Response
        {
            public Guid FoodId { get;set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public IAppDbContext _context { get; set; }
            public Handler(IAppDbContext context) => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
                var food = await _context.Foods.FindAsync(request.Food.FoodId);

                if (food == null) {
                    food = new Food();
                    _context.Foods.Add(food);
                }

                food.Name = request.Food.Name;
                food.Description = request.Food.Description;

                await _context.SaveChangesAsync(cancellationToken);

                return new Response() { FoodId = food.FoodId };
            }
        }
    }
}
