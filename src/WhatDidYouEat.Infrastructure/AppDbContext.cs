using Microsoft.EntityFrameworkCore;
using WhatDidYouEat.Core.Interfaces;
using WhatDidYouEat.Core.Models;

namespace WhatDidYouEat.Infrastructure
{
    public class AppDbContext: DbContext, IAppDbContext
    {
        public DbSet<Food> Foods { get; private set; }
        public DbSet<MenuItem> MenuItems { get; private set; }
        public DbSet<MenuType> MenuTypes { get; private set; }
        public DbSet<ScheduledMenu> ScheduledMenus { get; private set; }
        public AppDbContext(DbContextOptions options)
            : base(options) { }
    }
}
