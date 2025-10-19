using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionProjectSystem.Domain.Entities;
using System.Reflection;

namespace OnionProjectSystem.Persistence.Context
{
    public class OnionProjectSystemDbContext : IdentityDbContext<User,Role,Guid>
    {
        public OnionProjectSystemDbContext()
        {

        }
        public OnionProjectSystemDbContext(DbContextOptions<OnionProjectSystemDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
