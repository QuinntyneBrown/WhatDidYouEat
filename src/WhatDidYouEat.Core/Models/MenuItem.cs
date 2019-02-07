using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatDidYouEat.Core.Models
{
    public class MenuItem
    {
        public Guid MenuItemId { get; set; }
        [ForeignKey("MenuType")]
        public Guid MenuTypeId { get; set; }
        [ForeignKey("Food")]
        public Guid FoodId { get; set; }
        [ForeignKey("ScheduledMenu")]
        public Guid ScheduledMenuId { get; set; }
        public MenuType MenuType { get; set; }
        public Food Food { get; set; }
        public ScheduledMenu ScheduledMenu { get; set; }
    }
}
