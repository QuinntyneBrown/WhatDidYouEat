using System;

namespace WhatDidYouEat.Core.Models
{
    public class Food
    {
        public Guid FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
