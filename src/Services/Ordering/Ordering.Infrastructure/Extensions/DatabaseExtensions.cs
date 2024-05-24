﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await SeedAsync(context);
        }

        private static async Task SeedAsync(ApplicationDbContext context)
        {
            await SeedCustomerAsync(context);
            await SeedProductAsync(context);
            await SeedOrderandItemsAsync(context);
        }

        private static async Task SeedOrderandItemsAsync(ApplicationDbContext context)
        {
            if(!await context.OrderItems.AnyAsync())
            {
                await context.AddRangeAsync(InitialData.OrdersWithItems);
                await context.SaveChangesAsync();
            }
          
        }

        private static async Task SeedProductAsync(ApplicationDbContext context)
        {
            if(!await context.Products.AnyAsync())
            {
                await context.Products.AddRangeAsync(InitialData.Products);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedCustomerAsync(ApplicationDbContext context)
        {
            if(!await context.Customers.AnyAsync())
            {
                await context.Customers.AddRangeAsync(InitialData.Customers);
                await context.SaveChangesAsync();
            }
        }
    }
}
