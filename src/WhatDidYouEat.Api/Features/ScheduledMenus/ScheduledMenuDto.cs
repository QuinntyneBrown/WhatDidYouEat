using WhatDidYouEat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WhatDidYouEat.Api.Features.MenuItems;

namespace WhatDidYouEat.Api.Features.ScheduledMenus
{
    public class ScheduledMenuDto
    {        
        public Guid ScheduledMenuId { get; set; }
        public ICollection<MenuItemDto> MenuItems { get; set; }
        public DateTime Date { get; set; }
    }

    public static class ScheduledMenuExtensions
    {
        public static ScheduledMenuDto ToDto(this ScheduledMenu x)
            => new ScheduledMenuDto
            {
                MenuItems = x.MenuItems.Select(i => i.ToDto()).ToArray(),              
                Date = x.Date
            };
    }
}
