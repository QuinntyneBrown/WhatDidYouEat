using WhatDidYouEat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatDidYouEat.Api.Features.ScheduledMenus
{
    public class ScheduledMenuDto
    {        
        public Guid ScheduledMenuId { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public DateTime Date { get; set; }
    }

    public static class ScheduledMenuExtensions
    {
        public static ScheduledMenuDto ToDto(this ScheduledMenu x)
            => new ScheduledMenuDto
            {
                MenuItems = x.MenuItems
                .OrderBy(mt => mt.MenuType.OrderIndex).ToList(),
                Date = x.Date
            };
    }
}
