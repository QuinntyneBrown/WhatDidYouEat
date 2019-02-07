using WhatDidYouEat.Core.Models;
using System;

namespace WhatDidYouEat.Api.Features.MenuTypes
{
    public class MenuTypeDto
    {        
        public Guid MenuTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrderIndex { get; set; }
    }

    public static class MenuTypeExtensions
    {
        public static MenuTypeDto ToDto(this MenuType menuType)
            => new MenuTypeDto
            {
                MenuTypeId = menuType.MenuTypeId,
                Name = menuType.Name,
                Description = menuType.Description,
                OrderIndex = menuType.OrderIndex
            };
    }
}
