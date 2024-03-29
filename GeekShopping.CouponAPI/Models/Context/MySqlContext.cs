﻿using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        { }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        { }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 1,
                CouponCode = "10_OFF",
                DiscountAmount = 10
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 2,
                CouponCode = "15_OFF",
                DiscountAmount = 15
            });
        }
    }
}
