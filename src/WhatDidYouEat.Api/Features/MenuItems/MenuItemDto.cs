using WhatDidYouEat.Core.Models;
using System;
using WhatDidYouEat.Api.Features.MenuTypes;
using WhatDidYouEat.Api.Features.Foods;

namespace WhatDidYouEat.Api.Features.MenuItems
{
    public class MenuItemDto
    {
        public Guid MenuItemId { get; set; }        
        public Guid MenuTypeId { get; set; }        
        public Guid FoodId { get; set; }
        public Guid ScheduledMenuId { get; set; }
        public MenuTypeDto MenuType { get; set; }
        public FoodDto Food { get; set; }
    }

    public static class MenuItemExtensions
    {
        public static MenuItemDto ToDto(this MenuItem menuItem)
            => new MenuItemDto
            {
                MenuItemId = menuItem.MenuItemId,
                MenuTypeId = menuItem.MenuTypeId,
                FoodId = menuItem.FoodId,
                ScheduledMenuId = menuItem.ScheduledMenuId,
                Food = menuItem.Food.ToDto(),
                MenuType = menuItem.MenuType.ToDto() 
            };
    }
}
