using System;
using System.Collections.Generic;

namespace WhatDidYouEat.Core.Models
{
    public class ScheduledMenu
    {
        public Guid ScheduledMenuId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        = new HashSet<MenuItem>();
    }
}
