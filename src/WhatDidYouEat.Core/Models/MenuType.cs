using System;

namespace WhatDidYouEat.Core.Models
{
    public class MenuType
    {
        public Guid MenuTypeId { get; set; }
        public int OrderIndex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
    }
}
