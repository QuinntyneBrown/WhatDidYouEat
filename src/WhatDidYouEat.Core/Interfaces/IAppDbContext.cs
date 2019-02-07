using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WhatDidYouEat.Core.Models;

namespace WhatDidYouEat.Core.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Food> Foods { get; }
        DbSet<MenuItem> MenuItems { get; }
        DbSet<ScheduledMenu> ScheduledMenus { get; }
        DbSet<MenuType> MenuTypes { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
