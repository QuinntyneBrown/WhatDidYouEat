using WhatDidYouEat.Core.Models;
using System;

namespace WhatDidYouEat.Api.Features.Foods
{
    public class FoodDto
    {        
        public Guid FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public static class FoodExtensions
    {        
        public static FoodDto ToDto(this Food food)
            => new FoodDto
            {
                FoodId = food.FoodId,
                Name = food.Name,
                Description = food.Description
            };
    }
}
