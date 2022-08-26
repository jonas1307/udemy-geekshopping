using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        { }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Shirt",
                Price = 45,
                Description = "Lorem ipsum",
                ImageUrl = "https://moodle.com/wp-content/uploads/2021/03/22089-7.jpg",
                CategoryName = "T-Shirt"
            });
        }
    }
}
