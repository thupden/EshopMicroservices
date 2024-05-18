using DIscount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace DIscount.Grpc.Data
{
    public class DiscountContext: DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options): base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon()
                {
                    Id = 1,
                    ProductName = "IPhone 15",
                    Description = "Iphone Discount",
                    Amount = 1500
                },
                 new Coupon()
                 {
                     Id = 2,
                     ProductName = "Samsung 10",
                     Description = "Samsung Discount",
                     Amount = 2000
                 });
        }
    }
}
