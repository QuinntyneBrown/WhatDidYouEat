using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Linq;
using WhatDidYouEat.Core.Models;
using WhatDidYouEat.Infrastructure;

namespace WhatDidYouEat.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            ProcessDbCommands(args, host);

            host.Run();
        }

        private static void ProcessDbCommands(string[] args, IWebHost host)
        {
            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                if (args.Contains("ci"))
                    args = new string[4] { "dropdb", "migratedb", "seeddb", "stop" };

                if (args.Contains("dropdb"))
                    context.Database.EnsureDeleted();

                if (args.Contains("migratedb"))
                    context.Database.Migrate();

                if (args.Contains("seeddb"))
                {
                    context.Database.EnsureCreated();

                    if (context.Foods.FirstOrDefault(x => x.Name == "Unsalted soda crackers w/ cream cheese") == null)
                        context.Foods.Add(new Food { Name = "Unsalted soda crackers w/ cream cheese" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "2% milk") == null)
                        context.Foods.Add(new Food { Name = "2% milk" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Water") == null)
                        context.Foods.Add(new Food { Name = "Water" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Unsalted soda crackers w/ cream cheese") == null)
                        context.Foods.Add(new Food { Name = "Unsalted soda crackers w/ cream cheese" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Apples") == null)
                        context.Foods.Add(new Food { Name = "Apples" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Bananas") == null)
                        context.Foods.Add(new Food { Name = "Bananas" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Honey Dew") == null)
                        context.Foods.Add(new Food { Name = "Honey Dew" });
                    
                    if (context.Foods.FirstOrDefault(x => x.Name == "Oranges") == null)
                        context.Foods.Add(new Food { Name = "Oranges" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Banana Loaf") == null)
                        context.Foods.Add(new Food { Name = "Banana Loaf" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Melba toast and cheese") == null)
                        context.Foods.Add(new Food { Name = "Melba toast and cheese" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Bagel with cream cheese") == null)
                        context.Foods.Add(new Food { Name = "Bagel with cream cheese" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Whole wheat or white bread with cream cheese") == null)
                        context.Foods.Add(new Food { Name = "Whole wheat or white bread with cream cheese" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Baked blue berry muffin") == null)
                        context.Foods.Add(new Food { Name = "Baked blue berry muffin" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Soda crackers and cheddar cheese") == null)
                        context.Foods.Add(new Food { Name = "Soda crackers and cheddar cheese" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Oatmeal cookies") == null)
                        context.Foods.Add(new Food { Name = "Oatmeal cookies" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Digestive cookies") == null)
                        context.Foods.Add(new Food { Name = "Digestive cookies" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Spaghetti") == null)
                        context.Foods.Add(new Food { Name = "Spaghetti" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Chicken Curry") == null)
                        context.Foods.Add(new Food { Name = "Chicken Curry" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Chicken Fajita Wrap") == null)
                        context.Foods.Add(new Food { Name = "Chicken Fajita Wrap" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Congi") == null)
                        context.Foods.Add(new Food { Name = "Congi" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Chicken Burger") == null)
                        context.Foods.Add(new Food { Name = "Chicken Burger" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Beef stroganoff") == null)
                        context.Foods.Add(new Food { Name = "Beef stroganoff" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Chicken Adobo") == null)
                        context.Foods.Add(new Food { Name = "Chicken Adobo" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Beef Chili served w/ rice or bread") == null)
                        context.Foods.Add(new Food { Name = "Chicken Adobo" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Beef Stew") == null)
                        context.Foods.Add(new Food { Name = "Beef Stew" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Beef Burger") == null)
                        context.Foods.Add(new Food { Name = "Beef Burger" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Romaine lettuce, cucumber, carrots with Ranch or French salad dressing") == null)
                        context.Foods.Add(new Food { Name = "Romaine lettuce, cucumber, carrots with Ranch or French salad dressing" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Romaine lettuce with Ranch or French salad dressing") == null)
                        context.Foods.Add(new Food { Name = "Romaine lettuce with Ranch or French salad dressing" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Iceberg lettuce and spinach with Ranch or French salad dressing") == null)
                        context.Foods.Add(new Food { Name = "Iceberg lettuce and spinach with Ranch or French salad dressing" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Unsalted soda crackers") == null)
                        context.Foods.Add(new Food { Name = "Unsalted soda crackers" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Peach and Strawberry yogurt") == null)
                        context.Foods.Add(new Food { Name = "Peach and Strawberry yogurt" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Corn Flakes Cereal") == null)
                        context.Foods.Add(new Food { Name = "Corn Flakes Cereal" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "White or whole wheat bread w/ shredded cheddar and mozzarella cheese") == null)
                        context.Foods.Add(new Food { Name = "White or whole wheat bread w/ shredded cheddar and mozzarella cheese" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Waffles w/ butter and honey") == null)
                        context.Foods.Add(new Food { Name = "Waffles w/ butter and honey" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Grilled cheese sandwich") == null)
                        context.Foods.Add(new Food { Name = "Grilled cheese sandwich" });

                    if (context.Foods.FirstOrDefault(x => x.Name == "Pancakes w/ butter") == null)
                        context.Foods.Add(new Food { Name = "Pancakes w/ butter" });

                    if (context.MenuTypes.FirstOrDefault(x => x.Name == "Morning snack") == null)
                        context.MenuTypes.Add(new MenuType { Name = "Morning snack", OrderIndex = 0 });

                    if (context.MenuTypes.FirstOrDefault(x => x.Name == "Lunch") == null)
                        context.MenuTypes.Add(new MenuType { Name = "Lunch", OrderIndex = 1 });

                    if (context.MenuTypes.FirstOrDefault(x => x.Name == "Salad") == null)
                        context.MenuTypes.Add(new MenuType { Name = "Salad", OrderIndex = 2 });

                    if (context.MenuTypes.FirstOrDefault(x => x.Name == "Fruits") == null)
                        context.MenuTypes.Add(new MenuType { Name = "Fruits", OrderIndex = 3 });

                    if (context.MenuTypes.FirstOrDefault(x => x.Name == "Drinks") == null)
                        context.MenuTypes.Add(new MenuType { Name = "Drinks", OrderIndex = 4 });

                    if (context.MenuTypes.FirstOrDefault(x => x.Name == "Afternoon snack") == null)
                        context.MenuTypes.Add(new MenuType { Name = "Afternoon snack", OrderIndex = 5 });

                    context.SaveChanges();
                }

                if (args.Contains("stop"))
                    Environment.Exit(0);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseApplicationInsights()
            .UseSerilog((builderContext, config) =>
            {
                config
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.ApplicationInsightsTraces(new TelemetryClient());
            })
            .UseStartup<Startup>();
    }
}
